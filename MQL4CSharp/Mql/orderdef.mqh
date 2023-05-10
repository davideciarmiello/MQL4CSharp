//preso da fx blue copy trading e aggiunto closetime

struct OrderDef {
   int   ticket;           // for existing orders/positions, the local ticket number of the order/position
   string   positionId;       // the external position ID, from the sender
   int      type;             // type of order/position, using the MT4 values: 0=buy, 1=sell, 2=buy-limit, 3=sell-limit, 4=buy-stop, 5=sell-stop
   string   symbol;           
   double   volume;           // For the sender's order, the *NOTIONAL VOLUME*: lots x contract size. For receiver orders, the local lot size.
   double   openprice;
   double   closeprice;		   // As in MT4&5: current/close price. Opposite side of spread for market orders; same side of spread for pending orders
   datetime opentime;
   datetime closetime;
   double   sl;
   double   tp;
   double   profit;
   double   swap;
   double   commission;
   string   comment;          // DO NOT ALTER unless you also turn on UseOriginalOrderComments or UseCustomOrderComment (and then override the comment here). This can orphan positions, and make the copier close them because they cannot be reconciled against the sender's heartbeat
   int      magic;            // DO NOT ALTER. This will orphan positions. The copier will ignore and not manage any trades which don't have its specified magic number.
};

void ConvertCurrentOrderToOrderDef(OrderDef& order)
{
   order.ticket = OrderTicket();
   order.type = (int)OrderType();
   order.symbol = OrderSymbol();
   order.volume = OrderLots();
   order.openprice = OrderOpenPrice();
   order.closeprice = OrderClosePrice();
   order.opentime = OrderOpenTime();
   order.closetime = OrderCloseTime();
   order.sl = OrderStopLoss();
   order.tp = OrderTakeProfit();
   order.profit = OrderProfit();
   order.swap = OrderSwap();
   order.commission = OrderCommission();
   order.comment = OrderComment();
   order.magic = OrderMagicNumber();
}
string ConvertCurrentOrderToOrderDefString()
{
   string strOrder = "";
   StringAdd(strOrder, "TICKET\02" + IntegerToString(OrderTicket()));
   StringAdd(strOrder, "\01SYMBOL\02" + OrderSymbol());
   StringAdd(strOrder, "\01TYPE\02" + IntegerToString((int)OrderType()));
   StringAdd(strOrder, "\01VOLUME\02" + DoubleToString(OrderLots(), 2));
   StringAdd(strOrder, "\01OPENPRICE\02" + DoubleToString(OrderOpenPrice(), 8));
   StringAdd(strOrder, "\01SL\02" + DoubleToString(OrderStopLoss(), 8));
   StringAdd(strOrder, "\01TP\02" + DoubleToString(OrderTakeProfit(), 8));
   StringAdd(strOrder, "\01CLOSEPRICE\02" + DoubleToString(OrderClosePrice(), 8));
   StringAdd(strOrder, "\01OPENTIME\02" + IntegerToString(OrderOpenTime()));
   StringAdd(strOrder, "\01CLOSETIME\02" + IntegerToString(OrderCloseTime()));
   StringAdd(strOrder, "\01COMMENT\02" + OrderComment());
   StringAdd(strOrder, "\01MAGIC\02" + IntegerToString(OrderMagicNumber()));
   StringAdd(strOrder, "\01PROFIT\02" + DoubleToString(OrderProfit(), 2));
   StringAdd(strOrder, "\01SWAP\02" + DoubleToString(OrderSwap(), 2));
   StringAdd(strOrder, "\01COMMISSION\02" + DoubleToString(OrderCommission(), 2));

   return strOrder;
}
// Serialization of an OrderDef into a string
string ConvertOrderDefToString(OrderDef& order)
{
   string strOrder = "";
   StringAdd(strOrder, "TICKET\02" + IntegerToString(order.ticket));
   StringAdd(strOrder, "\01POSITIONID\02" + order.positionId);
   StringAdd(strOrder, "\01SYMBOL\02" + order.symbol);
   StringAdd(strOrder, "\01TYPE\02" + IntegerToString(order.type));
   StringAdd(strOrder, "\01VOLUME\02" + DoubleToString(order.volume, 2));
   StringAdd(strOrder, "\01OPENPRICE\02" + DoubleToString(order.openprice, 8));
   StringAdd(strOrder, "\01SL\02" + DoubleToString(order.sl, 8));
   StringAdd(strOrder, "\01TP\02" + DoubleToString(order.tp, 8));
   StringAdd(strOrder, "\01CLOSEPRICE\02" + DoubleToString(order.closeprice, 8));
   StringAdd(strOrder, "\01OPENTIME\02" + IntegerToString(order.opentime));
   StringAdd(strOrder, "\01CLOSETIME\02" + IntegerToString(order.closetime));
   StringAdd(strOrder, "\01COMMENT\02" + order.comment);
   StringAdd(strOrder, "\01MAGIC\02" + IntegerToString(order.magic));
   StringAdd(strOrder, "\01PROFIT\02" + DoubleToString(order.profit, 2));
   StringAdd(strOrder, "\01SWAP\02" + DoubleToString(order.swap, 2));
   StringAdd(strOrder, "\01COMMISSION\02" + DoubleToString(order.commission, 2));

   return strOrder;
}

// Deserialization of a string into an OrderDef
void ConvertStringToOrderDef(string strDef, OrderDef& order)
{
   string parts[];
   StringSplit(strDef, '\01', parts);
   int ctParts = ArraySize(parts);
   for (int i = 0; i < ctParts; i++) {
      string kp[];
      StringSplit(parts[i], '\02', kp);
      if (ArraySize(kp) == 2) {
         if (kp[0] == "TICKET") {
            order.ticket = (int)StringToInteger(kp[1]);
         } else if (kp[0] == "POSITIONID") {
            order.positionId = kp[1];
         } else if (kp[0] == "SYMBOL") {
            order.symbol = kp[1];
         } else if (kp[0] == "TYPE") {
            order.type = (int)StringToInteger(kp[1]);
         } else if (kp[0] == "VOLUME") {
            order.volume = StringToDouble(kp[1]);
         } else if (kp[0] == "OPENPRICE") {
            order.openprice = StringToDouble(kp[1]);
         } else if (kp[0] == "SL") {
            order.sl = StringToDouble(kp[1]);
         } else if (kp[0] == "TP") {
            order.tp = StringToDouble(kp[1]);
         } else if (kp[0] == "CLOSEPRICE") {
            order.closeprice = StringToDouble(kp[1]);
         } else if (kp[0] == "OPENTIME") {
            order.opentime = (datetime)StringToInteger(kp[1]);
         } else if (kp[0] == "CLOSETIME") {
            order.closetime = (datetime)StringToInteger(kp[1]);
         } else if (kp[0] == "COMMENT") {
            order.comment = kp[1];
         } else if (kp[0] == "MAGIC") {
            order.magic = (int)StringToInteger(kp[1]);
         } else if (kp[0] == "PROFIT") {
            order.profit = StringToDouble(kp[1]);
         } else if (kp[0] == "SWAP") {
            order.swap = StringToDouble(kp[1]);
         } else if (kp[0] == "COMMISSION") {
            order.commission = StringToDouble(kp[1]);
         }      
      }
   }
}

