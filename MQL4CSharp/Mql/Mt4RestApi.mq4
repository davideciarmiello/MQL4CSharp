/*
Copyright 2016 Jason Separovic

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/



#import "MQL4CSharp.dll"
void InitLogging();
void UnloadAll(long);
int ExecOnInit(long, string);
void RestServerStart(long, string);
void RestServerStop(long);
int InitRates(long, MqlRates&[], int);
void SetRatesSize(long, int);
void ExecOnDeinit(long);
void ExecOnTick(long);
void ExecOnTimer(long);
bool IsExecutingOnInit(long);
bool IsExecutingOnTick(long);
bool IsExecutingOnTimer(long);
bool IsExecutingOnDeinit(long);
bool IsCommandManagerReady(long);
int IsCommandWaiting(long);
int GetCommandId(long, int);
void GetCommandName(long, int, string &cmdName);
void GetCommandParams(long, int, string &cmdParams);
void SetBoolCommandResponse(long, int, bool, int);
void SetDoubleCommandResponse(long, int, double, int);
void SetIntCommandResponse(long, int, int, int);
void SetStringCommandResponse(long, int, string, int);
void SetVoidCommandResponse(long, int, int);
void SetLongCommandResponse(long, int, long, int);
void SetDateTimeCommandResponse(long, int, datetime, int);
void SetEnumCommandResponse(long, int, int, int);
bool CommandLock(long);
bool CommandUnlock(long);
#import

 
int ratesSize;
MqlRates rates[];
long chartID;
 
//input string CSharpFullTypeName = "MQL4CSharp.UserDefined.Strategy.MaCrossStrategy";
input string CSharpFullTypeName = "MQL4CSharp.UserDefined.Strategy.MQLRESTStrategy"; 
input string RestServerAddress = "127.0.0.1:1234";
input int LOGLEVEL = 3;

int INFO = 3;
int DEBUG = 4;
int TRACE = 5;
 
char DELIM = 29;

int DEFAULT_CHART_ID = 0;

int EVENT_TIMER_MILLIS = 1;

void maintainRates(long ix)
{
   // update rates array size
   if(ratesSize != ArraySize(rates)) 
   {
      SetRatesSize(ix, ArraySize(rates));
   }
}

void info(string m1, string m2 = "", string m3 = "", string m4 = "", string m5 = "", string m6 = "", string m7 = "", string m8 = "", string m9 = "", string m10 = "")
{
   if(LOGLEVEL >= INFO)
   {
      Print(StringTrimRight(StringFormat("[INFO] %s %s %s %s %s %s %s %s %s %s", m1,m2,m3,m4,m5,m6,m7,m8,m9,m10)));
   }
}

void debug(string m1, string m2 = "", string m3 = "", string m4 = "", string m5 = "", string m6 = "", string m7 = "", string m8 = "", string m9 = "", string m10 = "")
{
   if(LOGLEVEL >= DEBUG)
   {
      Print(StringTrimRight(StringFormat("[DEBUG] %s %s %s %s %s %s %s %s %s %s", m1,m2,m3,m4,m5,m6,m7,m8,m9,m10)));
   }
}

void trace(string m1, string m2 = "", string m3 = "", string m4 = "", string m5 = "", string m6 = "", string m7 = "", string m8 = "", string m9 = "", string m10 = "")
{
   if(LOGLEVEL >= TRACE)
   {
      Print(StringTrimRight(StringFormat("[TRACE] %s %s %s %s %s %s %s %s %s %s", m1,m2,m3,m4,m5,m6,m7,m8,m9,m10)));
   }
}

int getLastErrorPrivate() 
{
	int error = GetLastError();
	if (error == 4052) 
	{
		error = 0;
		ResetLastError();
	}
	return error;
}

bool executeCommands(long ix)
{
   trace("IsCommandWaiting(): " + IsCommandWaiting(ix));
   int requestId;
   while((requestId = IsCommandWaiting(ix)) != -1)
   {
      debug("Executing Commands");
      if(CommandLock(ix))
      {
         debug("Locked");
         int id = GetCommandId(ix, requestId);
         string name = "";
         string params = "";
         GetCommandName(ix, requestId, name);
         GetCommandParams(ix, requestId, params);
         
         debug("name: " +  name);
         debug("params: " +  params);
   
         // Parse the command
         string paramArray[];
         StringSplit(params, DELIM, paramArray);
   
         int returnType = getCommandReturnType(id);
   
         // reset last error
         ResetLastError();
         
         int error;
         if(returnType == RETURN_TYPE_BOOL)
         {
            bool boolresult = executeBoolCommand(id, paramArray);
            error = getLastErrorPrivate();
            trace ("command: " + name + ", params" + params + ", result: " + boolresult + ", error: " + error);
            SetBoolCommandResponse(ix, requestId, boolresult, error);
         }
         else if(returnType == RETURN_TYPE_DOUBLE)
         {
            double doubleresult = executeDoubleCommand(id, paramArray);
            error = getLastErrorPrivate();
            trace ("command: " + name + ", params" + params + ", result: " + doubleresult + ", error: " + error);
            SetDoubleCommandResponse(ix, requestId, doubleresult, error);
         }
         else if(returnType == RETURN_TYPE_INT)
         {
            int intresult = executeIntCommand(id, paramArray);
            error = getLastErrorPrivate();
            trace ("command: " + name + ", params" + params + ", result: " + intresult + ", error: " + error);
            SetIntCommandResponse(ix, requestId, intresult, error);
         }
         else if(returnType == RETURN_TYPE_STRING)
         {
            string stringresult = executeStringCommand(id, paramArray);
            error = getLastErrorPrivate();
            trace ("command: " + name + ", params" + params + ", result: " + stringresult + ", error: " + error);
            SetStringCommandResponse(ix, requestId, stringresult, error);
         }
         else if(returnType == RETURN_TYPE_VOID)
         {
            executeVoidCommand(id, paramArray);
            error = getLastErrorPrivate();
            trace ("command: " + name + ", params" + params + ", error: " + error);
            SetVoidCommandResponse(ix, requestId, error);
         }
         else if(returnType == RETURN_TYPE_LONG)
         {
            long longresult = executeLongCommand(id, paramArray);
            error = getLastErrorPrivate();
            trace ("command: " + name + ", params" + params + ", result: " + longresult + ", error: " + error);
            SetLongCommandResponse(ix, requestId, longresult, error);
         }
         else if(returnType == RETURN_TYPE_DATETIME)
         {
            datetime datetimeresult = executeDateTimeCommand(id, paramArray);
            error = getLastErrorPrivate();
            trace ("command: " + name + ", params" + params + ", result: " + datetimeresult + ", error: " + error);
            SetDateTimeCommandResponse(ix, requestId, datetimeresult, error);
         }
      
         debug("Unlocking");
         CommandUnlock(ix);
         debug("Unlocked");
      }

   }
   return false;
}



int OnInit()
{
   if(!IsDllsAllowed())
   {
      info("Require DLL imports.");
      return(INIT_FAILED);
   }
   EventSetMillisecondTimer(EVENT_TIMER_MILLIS);

   // Initialize log4net
   info("OnInit() Initializing logging");
   InitLogging();
   
   chartID = ChartID();
   info("OnInit() Initializing RestServer ", RestServerAddress);
   RestServerStart(chartID, RestServerAddress);

   // Copy the rates array and pass it to the library
   ArrayCopyRates(rates, NULL, 0);
   ratesSize = ArraySize(rates);   
   info("OnInit() ExecOnInit: ", chartID, ", ", CSharpFullTypeName);
   ExecOnInit(chartID, CSharpFullTypeName);
   
   info("OnInit() Waiting for Command Manager");
   while(!IsCommandManagerReady(chartID))
   {
   
   }
   
   info("OnInit() executeCommands on Init");
   if(IsExecutingOnInit(chartID))
   {
      trace("OnInit() IsExecutingOnInit(chartID)");
      executeCommands(chartID);
   }
   
   // execute default REST commands
   info("OnInit() executeCommands REST");
   executeCommands(DEFAULT_CHART_ID);
   
   info("OnInit() Initializing rates");
   InitRates(chartID, rates, ratesSize);

   info("OnInit() OnInit complete");
   return(INIT_SUCCEEDED);
}
 
void OnDeinit(const int reason)
{
   info("OnDeinit()");
   // Call the DLL onDeinit
   ExecOnDeinit(chartID);
   
   RestServerStop(chartID);
   
   // execute commands that are waiting
   if(IsExecutingOnDeinit(chartID))
   {
      executeCommands(chartID);
   }
   
   // execute default REST commands
   executeCommands(DEFAULT_CHART_ID);

   UnloadAll(chartID);
}

 
void OnTick()
{
   // Call the DLL onTick
   ExecOnTick(chartID);

   // execute commands that are waiting
   if(IsExecutingOnTick(chartID))
   {
      executeCommands(chartID);
   }

   // execute default REST commands
   executeCommands(DEFAULT_CHART_ID);
      
   // Keep the rates array size up to date
   maintainRates(chartID);
}


void OnTimer()
{
   ExecOnTimer(chartID);

   // execute commands that are waiting
   if(IsExecutingOnTimer(chartID))
   {
      executeCommands(chartID);
   }
   
   // execute default REST commands
   executeCommands(DEFAULT_CHART_ID);
}




int CONVERT_ENUM_ALIGN_MODE(string value)
{
    if(value == "ALIGN_LEFT")
    {
        return ALIGN_LEFT;
    }
    else if(value == "ALIGN_CENTER")
    {
        return ALIGN_CENTER;
    }
    else if(value == "ALIGN_RIGHT")
    {
        return ALIGN_RIGHT;
    }
    else
    {
         return -1;
    }
}

int CONVERT_COLOR(string value)
{
    if(value == "NONE")
    {
        return clrNONE;
    }
    else if(value == "White")
    {
        return clrWhite;
    }
    else if(value == "Snow")
    {
        return clrSnow;
    }
    else if(value == "MintCream")
    {
        return clrMintCream;
    }
    else if(value == "LavenderBlush")
    {
        return clrLavenderBlush;
    }
    else if(value == "AliceBlue")
    {
        return clrAliceBlue;
    }
    else if(value == "Honeydew")
    {
        return clrHoneydew;
    }
    else if(value == "Ivory")
    {
        return clrIvory;
    }
    else if(value == "Seashell")
    {
        return clrSeashell;
    }
    else if(value == "WhiteSmoke")
    {
        return clrWhiteSmoke;
    }
    else if(value == "OldLace")
    {
        return clrOldLace;
    }
    else if(value == "MistyRose")
    {
        return clrMistyRose;
    }
    else if(value == "Lavender")
    {
        return clrLavender;
    }
    else if(value == "Linen")
    {
        return clrLinen;
    }
    else if(value == "LightCyan")
    {
        return clrLightCyan;
    }
    else if(value == "LightYellow")
    {
        return clrLightYellow;
    }
    else if(value == "Cornsilk")
    {
        return clrCornsilk;
    }
    else if(value == "PapayaWhip")
    {
        return clrPapayaWhip;
    }
    else if(value == "AntiqueWhite")
    {
        return clrAntiqueWhite;
    }
    else if(value == "Beige")
    {
        return clrBeige;
    }
    else if(value == "LemonChiffon")
    {
        return clrLemonChiffon;
    }
    else if(value == "BlanchedAlmond")
    {
        return clrBlanchedAlmond;
    }
    else if(value == "LightGoldenrod")
    {
        return clrLightGoldenrod;
    }
    else if(value == "Bisque")
    {
        return clrBisque;
    }
    else if(value == "Pink")
    {
        return clrPink;
    }
    else if(value == "PeachPuff")
    {
        return clrPeachPuff;
    }
    else if(value == "Gainsboro")
    {
        return clrGainsboro;
    }
    else if(value == "Moccasin")
    {
        return clrMoccasin;
    }
    else if(value == "NavajoWhite")
    {
        return clrNavajoWhite;
    }
    else if(value == "Wheat")
    {
        return clrWheat;
    }
    else if(value == "PaleTurquoise")
    {
        return clrPaleTurquoise;
    }
    else if(value == "PaleGoldenrod")
    {
        return clrPaleGoldenrod;
    }
    else if(value == "PowderBlue")
    {
        return clrPowderBlue;
    }
    else if(value == "Thistle")
    {
        return clrThistle;
    }
    else if(value == "PaleGreen")
    {
        return clrPaleGreen;
    }
    else if(value == "LightBlue")
    {
        return clrLightBlue;
    }
    else if(value == "LightSteelBlue")
    {
        return clrLightSteelBlue;
    }
    else if(value == "LightSkyBlue")
    {
        return clrLightSkyBlue;
    }
    else if(value == "Silver")
    {
        return clrSilver;
    }
    else if(value == "Aquamarine")
    {
        return clrAquamarine;
    }
    else if(value == "LightGreen")
    {
        return clrLightGreen;
    }
    else if(value == "Khaki")
    {
        return clrKhaki;
    }
    else if(value == "Plum")
    {
        return clrPlum;
    }
    else if(value == "LightSalmon")
    {
        return clrLightSalmon;
    }
    else if(value == "SkyBlue")
    {
        return clrSkyBlue;
    }
    else if(value == "LightCoral")
    {
        return clrLightCoral;
    }
    else if(value == "Violet")
    {
        return clrViolet;
    }
    else if(value == "Salmon")
    {
        return clrSalmon;
    }
    else if(value == "HotPink")
    {
        return clrHotPink;
    }
    else if(value == "BurlyWood")
    {
        return clrBurlyWood;
    }
    else if(value == "DarkSalmon")
    {
        return clrDarkSalmon;
    }
    else if(value == "Tan")
    {
        return clrTan;
    }
    else if(value == "MediumSlateBlue")
    {
        return clrMediumSlateBlue;
    }
    else if(value == "SandyBrown")
    {
        return clrSandyBrown;
    }
    else if(value == "DarkGray")
    {
        return clrDarkGray;
    }
    else if(value == "CornflowerBlue")
    {
        return clrCornflowerBlue;
    }
    else if(value == "Coral")
    {
        return clrCoral;
    }
    else if(value == "PaleVioletRed")
    {
        return clrPaleVioletRed;
    }
    else if(value == "MediumPurple")
    {
        return clrMediumPurple;
    }
    else if(value == "Orchid")
    {
        return clrOrchid;
    }
    else if(value == "RosyBrown")
    {
        return clrRosyBrown;
    }
    else if(value == "Tomato")
    {
        return clrTomato;
    }
    else if(value == "DarkSeaGreen")
    {
        return clrDarkSeaGreen;
    }
    else if(value == "MediumAquamarine")
    {
        return clrMediumAquamarine;
    }
    else if(value == "GreenYellow")
    {
        return clrGreenYellow;
    }
    else if(value == "MediumOrchid")
    {
        return clrMediumOrchid;
    }
    else if(value == "IndianRed")
    {
        return clrIndianRed;
    }
    else if(value == "DarkKhaki")
    {
        return clrDarkKhaki;
    }
    else if(value == "SlateBlue")
    {
        return clrSlateBlue;
    }
    else if(value == "RoyalBlue")
    {
        return clrRoyalBlue;
    }
    else if(value == "Turquoise")
    {
        return clrTurquoise;
    }
    else if(value == "DodgerBlue")
    {
        return clrDodgerBlue;
    }
    else if(value == "MediumTurquoise")
    {
        return clrMediumTurquoise;
    }
    else if(value == "DeepPink")
    {
        return clrDeepPink;
    }
    else if(value == "LightSlateGray")
    {
        return clrLightSlateGray;
    }
    else if(value == "BlueViolet")
    {
        return clrBlueViolet;
    }
    else if(value == "Peru")
    {
        return clrPeru;
    }
    else if(value == "SlateGray")
    {
        return clrSlateGray;
    }
    else if(value == "Gray")
    {
        return clrGray;
    }
    else if(value == "Red")
    {
        return clrRed;
    }
    else if(value == "Magenta")
    {
        return clrMagenta;
    }
    else if(value == "Blue")
    {
        return clrBlue;
    }
    else if(value == "DeepSkyBlue")
    {
        return clrDeepSkyBlue;
    }
    else if(value == "Aqua")
    {
        return clrAqua;
    }
    else if(value == "SpringGreen")
    {
        return clrSpringGreen;
    }
    else if(value == "Lime")
    {
        return clrLime;
    }
    else if(value == "Chartreuse")
    {
        return clrChartreuse;
    }
    else if(value == "Yellow")
    {
        return clrYellow;
    }
    else if(value == "Gold")
    {
        return clrGold;
    }
    else if(value == "Orange")
    {
        return clrOrange;
    }
    else if(value == "DarkOrange")
    {
        return clrDarkOrange;
    }
    else if(value == "OrangeRed")
    {
        return clrOrangeRed;
    }
    else if(value == "LimeGreen")
    {
        return clrLimeGreen;
    }
    else if(value == "YellowGreen")
    {
        return clrYellowGreen;
    }
    else if(value == "DarkOrchid")
    {
        return clrDarkOrchid;
    }
    else if(value == "CadetBlue")
    {
        return clrCadetBlue;
    }
    else if(value == "LawnGreen")
    {
        return clrLawnGreen;
    }
    else if(value == "MediumSpringGreen")
    {
        return clrMediumSpringGreen;
    }
    else if(value == "Goldenrod")
    {
        return clrGoldenrod;
    }
    else if(value == "SteelBlue")
    {
        return clrSteelBlue;
    }
    else if(value == "Crimson")
    {
        return clrCrimson;
    }
    else if(value == "Chocolate")
    {
        return clrChocolate;
    }
    else if(value == "MediumSeaGreen")
    {
        return clrMediumSeaGreen;
    }
    else if(value == "MediumVioletRed")
    {
        return clrMediumVioletRed;
    }
    else if(value == "FireBrick")
    {
        return clrFireBrick;
    }
    else if(value == "DarkViolet")
    {
        return clrDarkViolet;
    }
    else if(value == "LightSeaGreen")
    {
        return clrLightSeaGreen;
    }
    else if(value == "DimGray")
    {
        return clrDimGray;
    }
    else if(value == "DarkTurquoise")
    {
        return clrDarkTurquoise;
    }
    else if(value == "Brown")
    {
        return clrBrown;
    }
    else if(value == "MediumBlue")
    {
        return clrMediumBlue;
    }
    else if(value == "Sienna")
    {
        return clrSienna;
    }
    else if(value == "DarkSlateBlue")
    {
        return clrDarkSlateBlue;
    }
    else if(value == "DarkGoldenrod")
    {
        return clrDarkGoldenrod;
    }
    else if(value == "SeaGreen")
    {
        return clrSeaGreen;
    }
    else if(value == "ForestGreen")
    {
        return clrForestGreen;
    }
    else if(value == "SaddleBrown")
    {
        return clrSaddleBrown;
    }
    else if(value == "DarkOliveGreen")
    {
        return clrDarkOliveGreen;
    }
    else if(value == "DarkBlue")
    {
        return clrDarkBlue;
    }
    else if(value == "MidnightBlue")
    {
        return clrMidnightBlue;
    }
    else if(value == "Indigo")
    {
        return clrIndigo;
    }
    else if(value == "Maroon")
    {
        return clrMaroon;
    }
    else if(value == "Purple")
    {
        return clrPurple;
    }
    else if(value == "Navy")
    {
        return clrNavy;
    }
    else if(value == "Teal")
    {
        return clrTeal;
    }
    else if(value == "Green")
    {
        return clrGreen;
    }
    else if(value == "Olive")
    {
        return clrOlive;
    }
    else if(value == "DarkSlateGray")
    {
        return clrDarkSlateGray;
    }
    else if(value == "DarkGreen")
    {
        return clrDarkGreen;
    }
    else if(value == "Black")
    {
        return clrBlack;
    }
    else
    {
         return -1;
    }
}

int CONVERT_ENUM_OBJECT(string value)
{
    if(value == "OBJ_VLINE")
    {
        return OBJ_VLINE;
    }
    else if(value == "OBJ_HLINE")
    {
        return OBJ_HLINE;
    }
    else if(value == "OBJ_TREND")
    {
        return OBJ_TREND;
    }
    else if(value == "OBJ_TRENDBYANGLE")
    {
        return OBJ_TRENDBYANGLE;
    }
    else if(value == "OBJ_CYCLES")
    {
        return OBJ_CYCLES;
    }
    else if(value == "OBJ_CHANNEL")
    {
        return OBJ_CHANNEL;
    }
    else if(value == "OBJ_STDDEVCHANNEL")
    {
        return OBJ_STDDEVCHANNEL;
    }
    else if(value == "OBJ_REGRESSION")
    {
        return OBJ_REGRESSION;
    }
    else if(value == "OBJ_PITCHFORK")
    {
        return OBJ_PITCHFORK;
    }
    else if(value == "OBJ_GANNLINE")
    {
        return OBJ_GANNLINE;
    }
    else if(value == "OBJ_GANNFAN")
    {
        return OBJ_GANNFAN;
    }
    else if(value == "OBJ_GANNGRID")
    {
        return OBJ_GANNGRID;
    }
    else if(value == "OBJ_FIBO")
    {
        return OBJ_FIBO;
    }
    else if(value == "OBJ_FIBOTIMES")
    {
        return OBJ_FIBOTIMES;
    }
    else if(value == "OBJ_FIBOFAN")
    {
        return OBJ_FIBOFAN;
    }
    else if(value == "OBJ_FIBOARC")
    {
        return OBJ_FIBOARC;
    }
    else if(value == "OBJ_FIBOCHANNEL")
    {
        return OBJ_FIBOCHANNEL;
    }
    else if(value == "OBJ_EXPANSION")
    {
        return OBJ_EXPANSION;
    }
    else if(value == "OBJ_RECTANGLE")
    {
        return OBJ_RECTANGLE;
    }
    else if(value == "OBJ_TRIANGLE")
    {
        return OBJ_TRIANGLE;
    }
    else if(value == "OBJ_ELLIPSE")
    {
        return OBJ_ELLIPSE;
    }
    else if(value == "OBJ_ARROW_THUMB_UP")
    {
        return OBJ_ARROW_THUMB_UP;
    }
    else if(value == "OBJ_ARROW_THUMB_DOWN")
    {
        return OBJ_ARROW_THUMB_DOWN;
    }
    else if(value == "OBJ_ARROW_UP")
    {
        return OBJ_ARROW_UP;
    }
    else if(value == "OBJ_ARROW_DOWN")
    {
        return OBJ_ARROW_DOWN;
    }
    else if(value == "OBJ_ARROW_STOP")
    {
        return OBJ_ARROW_STOP;
    }
    else if(value == "OBJ_ARROW_CHECK")
    {
        return OBJ_ARROW_CHECK;
    }
    else if(value == "OBJ_ARROW_LEFT_PRICE")
    {
        return OBJ_ARROW_LEFT_PRICE;
    }
    else if(value == "OBJ_ARROW_RIGHT_PRICE")
    {
        return OBJ_ARROW_RIGHT_PRICE;
    }
    else if(value == "OBJ_ARROW_BUY")
    {
        return OBJ_ARROW_BUY;
    }
    else if(value == "OBJ_ARROW_SELL")
    {
        return OBJ_ARROW_SELL;
    }
    else if(value == "OBJ_ARROW")
    {
        return OBJ_ARROW;
    }
    else if(value == "OBJ_TEXT")
    {
        return OBJ_TEXT;
    }
    else if(value == "OBJ_LABEL")
    {
        return OBJ_LABEL;
    }
    else if(value == "OBJ_BUTTON")
    {
        return OBJ_BUTTON;
    }
    else if(value == "OBJ_BITMAP")
    {
        return OBJ_BITMAP;
    }
    else if(value == "OBJ_BITMAP_LABEL")
    {
        return OBJ_BITMAP_LABEL;
    }
    else if(value == "OBJ_EDIT")
    {
        return OBJ_EDIT;
    }
    else if(value == "OBJ_EVENT")
    {
        return OBJ_EVENT;
    }
    else if(value == "OBJ_RECTANGLE_LABEL")
    {
        return OBJ_RECTANGLE_LABEL;
    }
    else
    {
         return -1;
    }
}

int CONVERT_ENUM_SIGNAL_BASE_DOUBLE(string value)
{
    if(value == "SIGNAL_BASE_BALANCE")
    {
        return SIGNAL_BASE_BALANCE;
    }
    else if(value == "SIGNAL_BASE_EQUITY")
    {
        return SIGNAL_BASE_EQUITY;
    }
    else if(value == "SIGNAL_BASE_GAIN")
    {
        return SIGNAL_BASE_GAIN;
    }
    else if(value == "SIGNAL_BASE_MAX_DRAWDOWN")
    {
        return SIGNAL_BASE_MAX_DRAWDOWN;
    }
    else if(value == "SIGNAL_BASE_PRICE")
    {
        return SIGNAL_BASE_PRICE;
    }
    else if(value == "SIGNAL_BASE_ROI")
    {
        return SIGNAL_BASE_ROI;
    }
    else
    {
         return -1;
    }
}

int CONVERT_ENUM_SIGNAL_BASE_INTEGER(string value)
{
    if(value == "SIGNAL_BASE_DATE_PUBLISHED")
    {
        return SIGNAL_BASE_DATE_PUBLISHED;
    }
    else if(value == "SIGNAL_BASE_DATE_STARTED")
    {
        return SIGNAL_BASE_DATE_STARTED;
    }
    else if(value == "SIGNAL_BASE_ID")
    {
        return SIGNAL_BASE_ID;
    }
    else if(value == "SIGNAL_BASE_LEVERAGE")
    {
        return SIGNAL_BASE_LEVERAGE;
    }
    else if(value == "SIGNAL_BASE_PIPS")
    {
        return SIGNAL_BASE_PIPS;
    }
    else if(value == "SIGNAL_BASE_RATING")
    {
        return SIGNAL_BASE_RATING;
    }
    else if(value == "SIGNAL_BASE_SUBSCRIBERS")
    {
        return SIGNAL_BASE_SUBSCRIBERS;
    }
    else if(value == "SIGNAL_BASE_TRADES")
    {
        return SIGNAL_BASE_TRADES;
    }
    else if(value == "SIGNAL_BASE_TRADE_MODE")
    {
        return SIGNAL_BASE_TRADE_MODE;
    }
    else
    {
         return -1;
    }
}

int CONVERT_ENUM_SIGNAL_BASE_STRING(string value)
{
    if(value == "SIGNAL_BASE_AUTHOR_LOGIN")
    {
        return SIGNAL_BASE_AUTHOR_LOGIN;
    }
    else if(value == "SIGNAL_BASE_BROKER")
    {
        return SIGNAL_BASE_BROKER;
    }
    else if(value == "SIGNAL_BASE_BROKER_SERVER")
    {
        return SIGNAL_BASE_BROKER_SERVER;
    }
    else if(value == "SIGNAL_BASE_NAME")
    {
        return SIGNAL_BASE_NAME;
    }
    else if(value == "SIGNAL_BASE_CURRENCY")
    {
        return SIGNAL_BASE_CURRENCY;
    }
    else
    {
         return -1;
    }
}

int CONVERT_ENUM_SIGNAL_INFO_DOUBLE(string value)
{
    if(value == "SIGNAL_INFO_EQUITY_LIMIT")
    {
        return SIGNAL_INFO_EQUITY_LIMIT;
    }
    else if(value == "SIGNAL_INFO_SLIPPAGE")
    {
        return SIGNAL_INFO_SLIPPAGE;
    }
    else if(value == "SIGNAL_INFO_VOLUME_PERCENT")
    {
        return SIGNAL_INFO_VOLUME_PERCENT;
    }
    else
    {
         return -1;
    }
}

int CONVERT_ENUM_SIGNAL_INFO_INTEGER(string value)
{
    if(value == "SIGNAL_INFO_CONFIRMATIONS_DISABLED")
    {
        return SIGNAL_INFO_CONFIRMATIONS_DISABLED;
    }
    else if(value == "SIGNAL_INFO_COPY_SLTP")
    {
        return SIGNAL_INFO_COPY_SLTP;
    }
    else if(value == "SIGNAL_INFO_DEPOSIT_PERCENT")
    {
        return SIGNAL_INFO_DEPOSIT_PERCENT;
    }
    else if(value == "SIGNAL_INFO_ID")
    {
        return SIGNAL_INFO_ID;
    }
    else if(value == "SIGNAL_INFO_SUBSCRIPTION_ENABLED")
    {
        return SIGNAL_INFO_SUBSCRIPTION_ENABLED;
    }
    else if(value == "SIGNAL_INFO_TERMS_AGREE")
    {
        return SIGNAL_INFO_TERMS_AGREE;
    }
    else
    {
         return -1;
    }
}

int CONVERT_ENUM_SIGNAL_INFO_STRING(string value)
{
    if(value == "SIGNAL_INFO_NAME")
    {
        return SIGNAL_INFO_NAME;
    }
    else
    {
         return -1;
    }
}

int CONVERT_ENUM_TIMEFRAMES(string value)
{
    if(value == "PERIOD_CURRENT")
    {
        return PERIOD_CURRENT;
    }
    else if(value == "PERIOD_M1")
    {
        return PERIOD_M1;
    }
    else if(value == "PERIOD_M5")
    {
        return PERIOD_M5;
    }
    else if(value == "PERIOD_M15")
    {
        return PERIOD_M15;
    }
    else if(value == "PERIOD_M30")
    {
        return PERIOD_M30;
    }
    else if(value == "PERIOD_H1")
    {
        return PERIOD_H1;
    }
    else if(value == "PERIOD_H4")
    {
        return PERIOD_H4;
    }
    else if(value == "PERIOD_D1")
    {
        return PERIOD_D1;
    }
    else if(value == "PERIOD_W1")
    {
        return PERIOD_W1;
    }
    else if(value == "PERIOD_MN1")
    {
        return PERIOD_MN1;
    }
    else
    {
         return -1;
    }
}

int RETURN_TYPE_BOOL = 1;
int RETURN_TYPE_DOUBLE = 2;
int RETURN_TYPE_INT = 3;
int RETURN_TYPE_STRING = 4;
int RETURN_TYPE_VOID = 5;
int RETURN_TYPE_LONG = 6;
int RETURN_TYPE_DATETIME = 7;
int RETURN_TYPE_ENUM = 8;

int getCommandReturnType(int id)
{
   switch(id)
   {
      case 1:
        return RETURN_TYPE_VOID;
      case 2:
        return RETURN_TYPE_VOID;
      case 3:
        return RETURN_TYPE_BOOL;
      case 4:
        return RETURN_TYPE_BOOL;
      case 5:
        return RETURN_TYPE_BOOL;
      case 6:
        return RETURN_TYPE_DOUBLE;
      case 7:
        return RETURN_TYPE_LONG;
      case 8:
        return RETURN_TYPE_STRING;
      case 9:
        return RETURN_TYPE_DOUBLE;
      case 10:
        return RETURN_TYPE_DOUBLE;
      case 11:
        return RETURN_TYPE_STRING;
      case 12:
        return RETURN_TYPE_STRING;
      case 13:
        return RETURN_TYPE_DOUBLE;
      case 14:
        return RETURN_TYPE_DOUBLE;
      case 15:
        return RETURN_TYPE_DOUBLE;
      case 16:
        return RETURN_TYPE_DOUBLE;
      case 17:
        return RETURN_TYPE_INT;
      case 18:
        return RETURN_TYPE_DOUBLE;
      case 19:
        return RETURN_TYPE_STRING;
      case 20:
        return RETURN_TYPE_INT;
      case 21:
        return RETURN_TYPE_DOUBLE;
      case 22:
        return RETURN_TYPE_STRING;
      case 23:
        return RETURN_TYPE_INT;
      case 24:
        return RETURN_TYPE_INT;
      case 25:
        return RETURN_TYPE_INT;
      case 26:
        return RETURN_TYPE_BOOL;
      case 27:
        return RETURN_TYPE_INT;
      case 28:
        return RETURN_TYPE_INT;
      case 29:
        return RETURN_TYPE_STRING;
      case 30:
        return RETURN_TYPE_VOID;
      case 31:
        return RETURN_TYPE_INT;
      case 32:
        return RETURN_TYPE_DOUBLE;
      case 33:
        return RETURN_TYPE_STRING;
      case 34:
        return RETURN_TYPE_STRING;
      case 35:
        return RETURN_TYPE_INT;
      case 36:
        return RETURN_TYPE_INT;
      case 37:
        return RETURN_TYPE_DOUBLE;
      case 38:
        return RETURN_TYPE_BOOL;
      case 39:
        return RETURN_TYPE_BOOL;
      case 40:
        return RETURN_TYPE_BOOL;
      case 41:
        return RETURN_TYPE_BOOL;
      case 42:
        return RETURN_TYPE_BOOL;
      case 43:
        return RETURN_TYPE_BOOL;
      case 44:
        return RETURN_TYPE_BOOL;
      case 45:
        return RETURN_TYPE_BOOL;
      case 46:
        return RETURN_TYPE_BOOL;
      case 47:
        return RETURN_TYPE_BOOL;
      case 48:
        return RETURN_TYPE_BOOL;
      case 49:
        return RETURN_TYPE_STRING;
      case 50:
        return RETURN_TYPE_STRING;
      case 51:
        return RETURN_TYPE_STRING;
      case 52:
        return RETURN_TYPE_DOUBLE;
      case 53:
        return RETURN_TYPE_INT;
      case 54:
        return RETURN_TYPE_STRING;
      case 55:
        return RETURN_TYPE_BOOL;
      case 56:
        return RETURN_TYPE_BOOL;
      case 57:
        return RETURN_TYPE_INT;
      case 58:
        return RETURN_TYPE_INT;
      case 59:
        return RETURN_TYPE_INT;
      case 60:
        return RETURN_TYPE_INT;
      case 61:
        return RETURN_TYPE_DOUBLE;
      case 62:
        return RETURN_TYPE_DOUBLE;
      case 63:
        return RETURN_TYPE_INT;
      case 64:
        return RETURN_TYPE_DOUBLE;
      case 65:
        return RETURN_TYPE_INT;
      case 66:
        return RETURN_TYPE_DOUBLE;
      case 67:
        return RETURN_TYPE_DATETIME;
      case 68:
        return RETURN_TYPE_LONG;
      case 69:
        return RETURN_TYPE_BOOL;
      case 70:
        return RETURN_TYPE_BOOL;
      case 71:
        return RETURN_TYPE_INT;
      case 72:
        return RETURN_TYPE_INT;
      case 73:
        return RETURN_TYPE_LONG;
      case 74:
        return RETURN_TYPE_LONG;
      case 75:
        return RETURN_TYPE_LONG;
      case 76:
        return RETURN_TYPE_BOOL;
      case 77:
        return RETURN_TYPE_STRING;
      case 78:
        return RETURN_TYPE_VOID;
      case 79:
        return RETURN_TYPE_BOOL;
      case 80:
        return RETURN_TYPE_BOOL;
      case 81:
        return RETURN_TYPE_BOOL;
      case 82:
        return RETURN_TYPE_BOOL;
      case 83:
        return RETURN_TYPE_BOOL;
      case 84:
        return RETURN_TYPE_LONG;
      case 85:
        return RETURN_TYPE_BOOL;
      case 86:
        return RETURN_TYPE_STRING;
      case 87:
        return RETURN_TYPE_INT;
      case 88:
        return RETURN_TYPE_INT;
      case 89:
        return RETURN_TYPE_DOUBLE;
      case 90:
        return RETURN_TYPE_DATETIME;
      case 91:
        return RETURN_TYPE_INT;
      case 92:
        return RETURN_TYPE_INT;
      case 93:
        return RETURN_TYPE_BOOL;
      case 94:
        return RETURN_TYPE_BOOL;
      case 95:
        return RETURN_TYPE_INT;
      case 96:
        return RETURN_TYPE_STRING;
      case 97:
        return RETURN_TYPE_INT;
      case 98:
        return RETURN_TYPE_INT;
      case 99:
        return RETURN_TYPE_INT;
      case 100:
        return RETURN_TYPE_INT;
      case 101:
        return RETURN_TYPE_INT;
      case 102:
        return RETURN_TYPE_INT;
      case 103:
        return RETURN_TYPE_INT;
      case 104:
        return RETURN_TYPE_DOUBLE;
      case 105:
        return RETURN_TYPE_VOID;
      case 106:
        return RETURN_TYPE_BOOL;
      case 107:
        return RETURN_TYPE_DATETIME;
      case 108:
        return RETURN_TYPE_INT;
      case 109:
        return RETURN_TYPE_INT;
      case 110:
        return RETURN_TYPE_INT;
      case 111:
        return RETURN_TYPE_BOOL;
      case 112:
        return RETURN_TYPE_BOOL;
      case 113:
        return RETURN_TYPE_DOUBLE;
      case 114:
        return RETURN_TYPE_DATETIME;
      case 115:
        return RETURN_TYPE_STRING;
      case 116:
        return RETURN_TYPE_DOUBLE;
      case 117:
        return RETURN_TYPE_BOOL;
      case 118:
        return RETURN_TYPE_DATETIME;
      case 119:
        return RETURN_TYPE_DOUBLE;
      case 120:
        return RETURN_TYPE_INT;
      case 121:
        return RETURN_TYPE_BOOL;
      case 122:
        return RETURN_TYPE_DOUBLE;
      case 123:
        return RETURN_TYPE_DATETIME;
      case 124:
        return RETURN_TYPE_VOID;
      case 125:
        return RETURN_TYPE_DOUBLE;
      case 126:
        return RETURN_TYPE_BOOL;
      case 127:
        return RETURN_TYPE_INT;
      case 128:
        return RETURN_TYPE_INT;
      case 129:
        return RETURN_TYPE_DOUBLE;
      case 130:
        return RETURN_TYPE_INT;
      case 131:
        return RETURN_TYPE_DOUBLE;
      case 132:
        return RETURN_TYPE_STRING;
      case 133:
        return RETURN_TYPE_DOUBLE;
      case 134:
        return RETURN_TYPE_INT;
      case 135:
        return RETURN_TYPE_INT;
      case 136:
        return RETURN_TYPE_DOUBLE;
      case 137:
        return RETURN_TYPE_LONG;
      case 138:
        return RETURN_TYPE_STRING;
      case 139:
        return RETURN_TYPE_BOOL;
      case 140:
        return RETURN_TYPE_INT;
      case 141:
        return RETURN_TYPE_DOUBLE;
      case 142:
        return RETURN_TYPE_LONG;
      case 143:
        return RETURN_TYPE_STRING;
      case 144:
        return RETURN_TYPE_BOOL;
      case 145:
        return RETURN_TYPE_BOOL;
      case 146:
        return RETURN_TYPE_BOOL;
      case 147:
        return RETURN_TYPE_BOOL;
      case 148:
        return RETURN_TYPE_BOOL;
      case 149:
        return RETURN_TYPE_DATETIME;
      case 150:
        return RETURN_TYPE_BOOL;
      case 151:
        return RETURN_TYPE_DOUBLE;
      case 152:
        return RETURN_TYPE_STRING;
      case 153:
        return RETURN_TYPE_DATETIME;
      case 154:
        return RETURN_TYPE_VOID;
      case 155:
        return RETURN_TYPE_BOOL;
      case 156:
        return RETURN_TYPE_BOOL;
      case 157:
        return RETURN_TYPE_INT;
      case 158:
        return RETURN_TYPE_INT;
      case 159:
        return RETURN_TYPE_VOID;
      case 160:
        return RETURN_TYPE_BOOL;
      case 161:
        return RETURN_TYPE_BOOL;
      case 162:
        return RETURN_TYPE_BOOL;
      case 163:
        return RETURN_TYPE_BOOL;
      case 164:
        return RETURN_TYPE_BOOL;
      case 165:
        return RETURN_TYPE_BOOL;
      case 166:
        return RETURN_TYPE_BOOL;
      case 167:
        return RETURN_TYPE_INT;
      case 168:
        return RETURN_TYPE_VOID;
      case 169:
        return RETURN_TYPE_VOID;
      case 170:
        return RETURN_TYPE_VOID;
      case 171:
        return RETURN_TYPE_VOID;
      case 172:
        return RETURN_TYPE_VOID;
      case 173:
        return RETURN_TYPE_VOID;
      case 174:
        return RETURN_TYPE_VOID;
      case 175:
        return RETURN_TYPE_VOID;
      case 176:
        return RETURN_TYPE_VOID;
      case 177:
        return RETURN_TYPE_VOID;
      case 178:
        return RETURN_TYPE_BOOL;
      case 179:
        return RETURN_TYPE_BOOL;
      case 1001:
        return RETURN_TYPE_BOOL;
      case 180:
        return RETURN_TYPE_STRING;
      case 181:
        return RETURN_TYPE_BOOL;
      case 182:
        return RETURN_TYPE_BOOL;
      case 183:
        return RETURN_TYPE_INT;
      case 184:
        return RETURN_TYPE_INT;
      case 185:
        return RETURN_TYPE_INT;
      case 186:
        return RETURN_TYPE_INT;
      case 187:
        return RETURN_TYPE_INT;
      case 188:
        return RETURN_TYPE_DATETIME;
      case 189:
        return RETURN_TYPE_DOUBLE;
      case 190:
        return RETURN_TYPE_BOOL;
      case 191:
        return RETURN_TYPE_INT;
      case 192:
        return RETURN_TYPE_INT;
      case 193:
        return RETURN_TYPE_DOUBLE;
      case 194:
        return RETURN_TYPE_LONG;
      case 195:
        return RETURN_TYPE_STRING;
      case 196:
        return RETURN_TYPE_BOOL;
      case 197:
        return RETURN_TYPE_BOOL;
      case 198:
        return RETURN_TYPE_BOOL;
      case 199:
        return RETURN_TYPE_BOOL;
      case 200:
        return RETURN_TYPE_BOOL;
      case 201:
        return RETURN_TYPE_BOOL;
      case 202:
        return RETURN_TYPE_BOOL;
      case 203:
        return RETURN_TYPE_STRING;
      case 204:
        return RETURN_TYPE_DOUBLE;
      case 205:
        return RETURN_TYPE_STRING;
      case 206:
        return RETURN_TYPE_INT;
      case 207:
        return RETURN_TYPE_DOUBLE;
      case 208:
        return RETURN_TYPE_BOOL;
      case 209:
        return RETURN_TYPE_BOOL;
      case 210:
        return RETURN_TYPE_BOOL;
      case 211:
        return RETURN_TYPE_INT;
      case 212:
        return RETURN_TYPE_DOUBLE;
      case 213:
        return RETURN_TYPE_DOUBLE;
      case 214:
        return RETURN_TYPE_DOUBLE;
      case 215:
        return RETURN_TYPE_DOUBLE;
      case 216:
        return RETURN_TYPE_DOUBLE;
      case 217:
        return RETURN_TYPE_DOUBLE;
      case 218:
        return RETURN_TYPE_DOUBLE;
      case 219:
        return RETURN_TYPE_DOUBLE;
      case 220:
        return RETURN_TYPE_DOUBLE;
      case 221:
        return RETURN_TYPE_DOUBLE;
      case 222:
        return RETURN_TYPE_DOUBLE;
      case 223:
        return RETURN_TYPE_DOUBLE;
      case 224:
        return RETURN_TYPE_DOUBLE;
      case 225:
        return RETURN_TYPE_DOUBLE;
      case 226:
        return RETURN_TYPE_DOUBLE;
      case 227:
        return RETURN_TYPE_DOUBLE;
      case 228:
        return RETURN_TYPE_DOUBLE;
      case 229:
        return RETURN_TYPE_DOUBLE;
      case 230:
        return RETURN_TYPE_DOUBLE;
      case 231:
        return RETURN_TYPE_DOUBLE;
      case 232:
        return RETURN_TYPE_DOUBLE;
      case 233:
        return RETURN_TYPE_DOUBLE;
      case 234:
        return RETURN_TYPE_DOUBLE;
      case 235:
        return RETURN_TYPE_DOUBLE;
      case 236:
        return RETURN_TYPE_DOUBLE;
      case 237:
        return RETURN_TYPE_DOUBLE;
      case 238:
        return RETURN_TYPE_DOUBLE;
      case 239:
        return RETURN_TYPE_DOUBLE;
      case 240:
        return RETURN_TYPE_DOUBLE;

      default:
         return -1;

   }
}




bool executeBoolCommand(int id, string params[])
{
   switch(id)
   {
      case 3:
         return SendFTP(params[0], params[1]);
      case 4:
         return SendNotification(params[0]);
      case 5:
         return SendMail(params[0], params[1]);
      case 26:
         return IsStopped();
      case 38:
         return IsConnected();
      case 39:
         return IsDemo();
      case 40:
         return IsDllsAllowed();
      case 41:
         return IsExpertEnabled();
      case 42:
         return IsLibrariesAllowed();
      case 43:
         return IsOptimization();
      case 44:
         return IsTesting();
      case 45:
         return IsTradeAllowed();
      case 46:
         return IsTradeAllowed(params[0], StringToTime(params[1]));
      case 47:
         return IsTradeContextBusy();
      case 48:
         return IsVisualMode();
      case 55:
         return SymbolSelect(params[0], StringCompare(params[1],"true",false)==0);
      case 56:
         return RefreshRates();
      case 69:
         return ChartApplyTemplate(StringToInteger(params[0]), params[1]);
      case 70:
         return ChartSaveTemplate(StringToInteger(params[0]), params[1]);
      case 76:
         return ChartClose(StringToInteger(params[0]));
      case 79:
         return ChartSetDouble(StringToInteger(params[0]), StrToInteger(params[1]), StringToDouble(params[2]));
      case 80:
         return ChartSetInteger(StringToInteger(params[0]), StrToInteger(params[1]), StringToInteger(params[2]));
      case 81:
         return ChartSetInteger(StringToInteger(params[0]), StrToInteger(params[1]), StringToInteger(params[3]));
      case 82:
         return ChartSetString(StringToInteger(params[0]), StrToInteger(params[1]), params[2]);
      case 83:
         return ChartNavigate(StringToInteger(params[0]), StrToInteger(params[1]), StrToInteger(params[2]));
      case 85:
         return ChartIndicatorDelete(StringToInteger(params[0]), StrToInteger(params[1]), params[2]);
      case 93:
         return ChartSetSymbolPeriod(StringToInteger(params[0]), params[1], CONVERT_ENUM_TIMEFRAMES(params[2]));
      case 94:
         return ChartScreenShot(StringToInteger(params[0]), params[1], StrToInteger(params[2]), StrToInteger(params[3]), CONVERT_ENUM_ALIGN_MODE(params[4]));
      case 106:
         return WindowScreenShot(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]));
      case 111:
         return OrderClose(StrToInteger(params[0]), StringToDouble(params[1]), StringToDouble(params[2]), StrToInteger(params[3]), CONVERT_COLOR(params[4]));
      case 112:
         return OrderCloseBy(StrToInteger(params[0]), StrToInteger(params[1]), CONVERT_COLOR(params[2]));
      case 117:
         return OrderDelete(StrToInteger(params[0]), CONVERT_COLOR(params[1]));
      case 121:
         return OrderModify(StrToInteger(params[0]), StringToDouble(params[1]), StringToDouble(params[2]), StringToDouble(params[3]), StringToTime(params[4]), CONVERT_COLOR(params[5]));
      case 126:
         return OrderSelect(StrToInteger(params[0]), StrToInteger(params[1]), StrToInteger(params[2]));
      case 139:
         return SignalBaseSelect(StrToInteger(params[0]));
      case 144:
         return SignalInfoSetDouble(CONVERT_ENUM_SIGNAL_INFO_DOUBLE(params[0]), StringToDouble(params[1]));
      case 145:
         return SignalInfoSetInteger(CONVERT_ENUM_SIGNAL_INFO_INTEGER(params[0]), StringToInteger(params[1]));
      case 146:
         return SignalSubscribe(StringToInteger(params[0]));
      case 147:
         return SignalUnsubscribe();
      case 148:
         return GlobalVariableCheck(params[0]);
      case 150:
         return GlobalVariableDel(params[0]);
      case 155:
         return GlobalVariableTemp(params[0]);
      case 156:
         return GlobalVariableSetOnCondition(params[0], StringToDouble(params[1]), StringToDouble(params[2]));
      case 160:
         return IndicatorSetDouble(StrToInteger(params[0]), StringToDouble(params[1]));
      case 161:
         return IndicatorSetDouble(StrToInteger(params[0]), StrToInteger(params[1]), StringToDouble(params[2]));
      case 162:
         return IndicatorSetInteger(StrToInteger(params[0]), StrToInteger(params[1]));
      case 163:
         return IndicatorSetInteger(StrToInteger(params[0]), StrToInteger(params[1]), StrToInteger(params[2]));
      case 164:
         return IndicatorSetString(StrToInteger(params[0]), params[1]);
      case 165:
         return IndicatorSetString(StrToInteger(params[0]), StrToInteger(params[1]), params[2]);
      case 166:
         return IndicatorBuffers(StrToInteger(params[0]));
      case 178:
         return ObjectCreate(StringToInteger(params[0]), params[1], CONVERT_ENUM_OBJECT(params[2]), StrToInteger(params[3]), StringToTime(params[4]), StringToDouble(params[5]), StringToTime(params[6]), StringToDouble(params[7]));
      case 179:
         return ObjectCreate(params[0], CONVERT_ENUM_OBJECT(params[1]), StrToInteger(params[2]), StringToTime(params[3]), StringToDouble(params[4]), StringToTime(params[5]), StringToDouble(params[6]), StringToTime(params[7]), StringToDouble(params[8]));
      case 1001:
         return ObjectCreate(params[0], CONVERT_ENUM_OBJECT(params[1]), StrToInteger(params[2]), StringToTime(params[3]), StringToDouble(params[4]));
      case 181:
         return ObjectDelete(StringToInteger(params[0]), params[1]);
      case 182:
         return ObjectDelete(params[0]);
      case 190:
         return ObjectMove(params[0], StrToInteger(params[1]), StringToTime(params[2]), StringToDouble(params[3]));
      case 196:
         return ObjectSetDouble(StringToInteger(params[0]), params[1], StrToInteger(params[2]), StringToDouble(params[3]));
      case 197:
         return ObjectSetDouble(StringToInteger(params[0]), params[1], StrToInteger(params[2]), StrToInteger(params[3]), StringToDouble(params[4]));
      case 198:
         return ObjectSetInteger(StringToInteger(params[0]), params[1], StrToInteger(params[2]), StringToInteger(params[3]));
      case 199:
         return ObjectSetInteger(StringToInteger(params[0]), params[1], StrToInteger(params[2]), StrToInteger(params[3]), StringToInteger(params[4]));
      case 200:
         return ObjectSetString(StringToInteger(params[0]), params[1], StrToInteger(params[2]), params[3]);
      case 201:
         return ObjectSetString(StringToInteger(params[0]), params[1], StrToInteger(params[2]), StrToInteger(params[3]), params[4]);
      case 202:
         return TextSetFont(params[0], StrToInteger(params[1]), StrToInteger(params[3]));
      case 208:
         return ObjectSet(params[0], StrToInteger(params[1]), StringToDouble(params[2]));
      case 209:
         return ObjectSetFiboDescription(params[0], StrToInteger(params[1]), params[2]);
      case 210:
         return ObjectSetText(params[0], params[1], StrToInteger(params[2]), params[3], CONVERT_COLOR(params[4]));
   }
}

double executeDoubleCommand(int id, string params[])
{
   switch(id)
   {
      case 6:
         return AccountInfoDouble(StrToInteger(params[0]));
      case 9:
         return AccountBalance();
      case 10:
         return AccountCredit();
      case 13:
         return AccountEquity();
      case 14:
         return AccountFreeMargin();
      case 15:
         return AccountFreeMarginCheck(params[0], StrToInteger(params[1]), StringToDouble(params[2]));
      case 16:
         return AccountFreeMarginMode();
      case 18:
         return AccountMargin();
      case 21:
         return AccountProfit();
      case 32:
         return TerminalInfoDouble(StrToInteger(params[0]));
      case 37:
         return Point();
      case 52:
         return MarketInfo(params[0], StrToInteger(params[1]));
      case 61:
         return iClose(params[0], StrToInteger(params[1]), StrToInteger(params[2]));
      case 62:
         return iHigh(params[0], StrToInteger(params[1]), StrToInteger(params[2]));
      case 64:
         return iLow(params[0], StrToInteger(params[1]), StrToInteger(params[2]));
      case 66:
         return iOpen(params[0], StrToInteger(params[1]), StrToInteger(params[2]));
      case 89:
         return ChartPriceOnDropped();
      case 104:
         return WindowPriceOnDropped();
      case 113:
         return OrderClosePrice();
      case 116:
         return OrderCommission();
      case 119:
         return OrderLots();
      case 122:
         return OrderOpenPrice();
      case 125:
         return OrderProfit();
      case 129:
         return OrderStopLoss();
      case 131:
         return OrderSwap();
      case 133:
         return OrderTakeProfit();
      case 136:
         return SignalBaseGetDouble(CONVERT_ENUM_SIGNAL_BASE_DOUBLE(params[0]));
      case 141:
         return SignalInfoGetDouble(CONVERT_ENUM_SIGNAL_INFO_DOUBLE(params[0]));
      case 151:
         return GlobalVariableGet(params[0]);
      case 189:
         return ObjectGetValueByTime(StringToInteger(params[0]), params[1], StringToTime(params[2]), StrToInteger(params[3]));
      case 193:
         return ObjectGetDouble(StringToInteger(params[0]), params[1], StrToInteger(params[2]), StrToInteger(params[3]));
      case 204:
         return ObjectGet(params[0], StrToInteger(params[1]));
      case 207:
         return ObjectGetValueByShift(params[0], StrToInteger(params[1]));
      case 212:
         return iAC(params[0], StrToInteger(params[1]), StrToInteger(params[2]));
      case 213:
         return iAD(params[0], StrToInteger(params[1]), StrToInteger(params[2]));
      case 214:
         return iADX(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]));
      case 215:
         return iAlligator(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]), StrToInteger(params[6]), StrToInteger(params[7]), StrToInteger(params[8]), StrToInteger(params[9]), StrToInteger(params[10]), StrToInteger(params[11]));
      case 216:
         return iAO(params[0], StrToInteger(params[1]), StrToInteger(params[2]));
      case 217:
         return iATR(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]));
      case 218:
         return iBearsPower(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]));
      case 219:
         return iBands(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StringToDouble(params[3]), StrToInteger(params[4]), StrToInteger(params[5]), StrToInteger(params[6]), StrToInteger(params[7]));
      case 220:
         return iBullsPower(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]));
      case 221:
         return iCCI(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]));
      case 222:
         return iDeMarker(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]));
      case 223:
         return iEnvelopes(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]), StringToDouble(params[6]), StrToInteger(params[7]), StrToInteger(params[8]));
      case 224:
         return iForce(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]));
      case 225:
         return iFractals(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]));
      case 226:
         return iGator(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]), StrToInteger(params[6]), StrToInteger(params[7]), StrToInteger(params[8]), StrToInteger(params[9]), StrToInteger(params[10]), StrToInteger(params[11]));
      case 227:
         return iIchimoku(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]), StrToInteger(params[6]));
      case 228:
         return iBWMFI(params[0], StrToInteger(params[1]), StrToInteger(params[2]));
      case 229:
         return iMomentum(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]));
      case 230:
         return iMFI(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]));
      case 231:
         return iMA(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]), StrToInteger(params[6]));
      case 232:
         return iOsMA(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]), StrToInteger(params[6]));
      case 233:
         return iMACD(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]), StrToInteger(params[6]), StrToInteger(params[7]));
      case 234:
         return iOBV(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]));
      case 235:
         return iSAR(params[0], StrToInteger(params[1]), StringToDouble(params[2]), StringToDouble(params[3]), StrToInteger(params[4]));
      case 236:
         return iRSI(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]));
      case 237:
         return iRVI(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]));
      case 238:
         return iStdDev(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]), StrToInteger(params[6]));
      case 239:
         return iStochastic(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]), StrToInteger(params[5]), StrToInteger(params[6]), StrToInteger(params[7]), StrToInteger(params[8]));
      case 240:
         return iWPR(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]));
   }
}

int executeIntCommand(int id, string params[])
{
   switch(id)
   {
      case 17:
         return AccountLeverage();
      case 20:
         return AccountNumber();
      case 23:
         return AccountStopoutLevel();
      case 24:
         return AccountStopoutMode();
      case 25:
         return GetLastError();
      case 27:
         return UninitializeReason();
      case 28:
         return MQLInfoInteger(StrToInteger(params[0]));
      case 31:
         return TerminalInfoInteger(StrToInteger(params[0]));
      case 35:
         return Period();
      case 36:
         return Digits();
      case 53:
         return SymbolsTotal(StringCompare(params[0],"true",false)==0);
      case 57:
         return Bars(params[0], CONVERT_ENUM_TIMEFRAMES(params[1]));
      case 58:
         return Bars(params[0], CONVERT_ENUM_TIMEFRAMES(params[1]), StringToTime(params[2]), StringToTime(params[3]));
      case 59:
         return iBars(params[0], StrToInteger(params[1]));
      case 60:
         return iBarShift(params[0], StrToInteger(params[1]), StringToTime(params[2]), StringCompare(params[3],"true",false)==0);
      case 63:
         return iHighest(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]));
      case 65:
         return iLowest(params[0], StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), StrToInteger(params[4]));
      case 71:
         return ChartWindowFind(StringToInteger(params[0]), params[1]);
      case 72:
         return ChartWindowFind();
      case 87:
         return ChartIndicatorsTotal(StringToInteger(params[0]), StrToInteger(params[1]));
      case 88:
         return ChartWindowOnDropped();
      case 91:
         return ChartXOnDropped();
      case 92:
         return ChartYOnDropped();
      case 95:
         return WindowBarsPerChart();
      case 97:
         return WindowFind(params[0]);
      case 98:
         return WindowFirstVisibleBar();
      case 99:
         return WindowHandle(params[0], StrToInteger(params[1]));
      case 100:
         return WindowIsVisible(StrToInteger(params[0]));
      case 101:
         return WindowOnDropped();
      case 102:
         return WindowPriceMax(StrToInteger(params[0]));
      case 103:
         return WindowPriceMin(StrToInteger(params[0]));
      case 108:
         return WindowsTotal();
      case 109:
         return WindowXOnDropped();
      case 110:
         return WindowYOnDropped();
      case 120:
         return OrderMagicNumber();
      case 127:
         return OrderSend(params[0], StrToInteger(params[1]), StringToDouble(params[2]), StringToDouble(params[3]), StrToInteger(params[4]), StringToDouble(params[5]), StringToDouble(params[6]), params[7], StrToInteger(params[8]), StringToTime(params[9]), CONVERT_COLOR(params[10]));
      case 128:
         return OrdersHistoryTotal();
      case 130:
         return OrdersTotal();
      case 134:
         return OrderTicket();
      case 135:
         return OrderType();
      case 140:
         return SignalBaseTotal();
      case 157:
         return GlobalVariablesDeleteAll(params[0], StringToTime(params[1]));
      case 158:
         return GlobalVariablesTotal();
      case 167:
         return IndicatorCounted();
      case 183:
         return ObjectsDeleteAll(StringToInteger(params[0]), StrToInteger(params[1]), StrToInteger(params[2]));
      case 184:
         return ObjectsDeleteAll(StrToInteger(params[0]), StrToInteger(params[1]));
      case 185:
         return ObjectsDeleteAll(StringToInteger(params[0]), params[1], StrToInteger(params[2]), StrToInteger(params[3]));
      case 186:
         return ObjectFind(StringToInteger(params[0]), params[1]);
      case 187:
         return ObjectFind(params[0]);
      case 191:
         return ObjectsTotal(StringToInteger(params[0]), StrToInteger(params[1]), StrToInteger(params[2]));
      case 192:
         return ObjectsTotal(StrToInteger(params[0]));
      case 206:
         return ObjectGetShiftByValue(params[0], StringToDouble(params[1]));
      case 211:
         return ObjectType(params[0]);
   }
}

string executeStringCommand(int id, string params[])
{
   switch(id)
   {
      case 8:
         return AccountInfoString(StrToInteger(params[0]));
      case 11:
         return AccountCompany();
      case 12:
         return AccountCurrency();
      case 19:
         return AccountName();
      case 22:
         return AccountServer();
      case 29:
         return MQLInfoString(StrToInteger(params[0]));
      case 33:
         return TerminalInfoString(StrToInteger(params[0]));
      case 34:
         return Symbol();
      case 49:
         return TerminalCompany();
      case 50:
         return TerminalName();
      case 51:
         return TerminalPath();
      case 54:
         return SymbolName(StrToInteger(params[0]), StringCompare(params[1],"true",false)==0);
      case 77:
         return ChartSymbol(StringToInteger(params[0]));
      case 86:
         return ChartIndicatorName(StringToInteger(params[0]), StrToInteger(params[1]), StrToInteger(params[2]));
      case 96:
         return WindowExpertName();
      case 115:
         return OrderComment();
      case 132:
         return OrderSymbol();
      case 138:
         return SignalBaseGetString(CONVERT_ENUM_SIGNAL_BASE_STRING(params[0]));
      case 143:
         return SignalInfoGetString(CONVERT_ENUM_SIGNAL_INFO_STRING(params[0]));
      case 152:
         return GlobalVariableName(StrToInteger(params[0]));
      case 180:
         return ObjectName(StrToInteger(params[0]));
      case 195:
         return ObjectGetString(StringToInteger(params[0]), params[1], StrToInteger(params[2]), StrToInteger(params[3]));
      case 203:
         return ObjectDescription(params[0]);
      case 205:
         return ObjectGetFiboDescription(params[0], StrToInteger(params[1]));
   }
}

void executeVoidCommand(int id, string params[])
{
   switch(id)
   {
      case 1:
          Alert(params[0]);
          break;
      case 2:
          Comment(params[0]);
          break;
      case 30:
          MQLSetInteger(StrToInteger(params[0]), StrToInteger(params[1]));
          break;
      case 78:
          ChartRedraw(StringToInteger(params[0]));
          break;
      case 105:
          WindowRedraw();
          break;
      case 124:
          OrderPrint();
          break;
      case 154:
          GlobalVariablesFlush();
          break;
      case 159:
          HideTestIndicators(StringCompare(params[0],"true",false)==0);
          break;
      case 168:
          IndicatorDigits(StrToInteger(params[0]));
          break;
      case 169:
          IndicatorShortName(params[0]);
          break;
      case 170:
          SetIndexArrow(StrToInteger(params[0]), StrToInteger(params[1]));
          break;
      case 171:
          SetIndexDrawBegin(StrToInteger(params[0]), StrToInteger(params[1]));
          break;
      case 172:
          SetIndexEmptyValue(StrToInteger(params[0]), StringToDouble(params[1]));
          break;
      case 173:
          SetIndexLabel(StrToInteger(params[0]), params[1]);
          break;
      case 174:
          SetIndexShift(StrToInteger(params[0]), StrToInteger(params[1]));
          break;
      case 175:
          SetIndexStyle(StrToInteger(params[0]), StrToInteger(params[1]), StrToInteger(params[2]), StrToInteger(params[3]), CONVERT_COLOR(params[4]));
          break;
      case 176:
          SetLevelStyle(StrToInteger(params[0]), StrToInteger(params[1]), CONVERT_COLOR(params[2]));
          break;
      case 177:
          SetLevelValue(StrToInteger(params[0]), StringToDouble(params[1]));
          break;
   }
}

long executeLongCommand(int id, string params[])
{
   switch(id)
   {
      case 7:
         return AccountInfoInteger(StrToInteger(params[0]));
      case 68:
         return iVolume(params[0], StrToInteger(params[1]), StrToInteger(params[2]));
      case 73:
         return ChartOpen(params[0], CONVERT_ENUM_TIMEFRAMES(params[1]));
      case 74:
         return ChartFirst();
      case 75:
         return ChartNext(StringToInteger(params[0]));
      case 84:
         return ChartID();
      case 137:
         return SignalBaseGetInteger(CONVERT_ENUM_SIGNAL_BASE_INTEGER(params[0]));
      case 142:
         return SignalInfoGetInteger(CONVERT_ENUM_SIGNAL_INFO_INTEGER(params[0]));
      case 194:
         return ObjectGetInteger(StringToInteger(params[0]), params[1], StrToInteger(params[2]), StrToInteger(params[3]));
   }
}

datetime executeDateTimeCommand(int id, string params[])
{
   switch(id)
   {
      case 67:
         return iTime(params[0], StrToInteger(params[1]), StrToInteger(params[2]));
      case 90:
         return ChartTimeOnDropped();
      case 107:
         return WindowTimeOnDropped();
      case 114:
         return OrderCloseTime();
      case 118:
         return OrderExpiration();
      case 123:
         return OrderOpenTime();
      case 149:
         return GlobalVariableTime(params[0]);
      case 153:
         return GlobalVariableSet(params[0], StringToDouble(params[1]));
      case 188:
         return ObjectGetTimeByValue(params[0], StringToDouble(params[1]), StrToInteger(params[2]));
   }
}
