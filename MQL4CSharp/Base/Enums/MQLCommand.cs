﻿/*
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


namespace MQL4CSharp.Base.Enums
{
    public enum MQLCommand
    {
        Alert_1 = 1,
        Comment_1 = 2,
        SendFTP_1 = 3,
        SendNotification_1 = 4,
        SendMail_1 = 5,
        AccountInfoDouble_1 = 6,
        AccountInfoInteger_1 = 7,
        AccountInfoString_1 = 8,
        AccountBalance_1 = 9,
        AccountCredit_1 = 10,
        AccountCompany_1 = 11,
        AccountCurrency_1 = 12,
        AccountEquity_1 = 13,
        AccountFreeMargin_1 = 14,
        AccountFreeMarginCheck_1 = 15,
        AccountFreeMarginMode_1 = 16,
        AccountLeverage_1 = 17,
        AccountMargin_1 = 18,
        AccountName_1 = 19,
        AccountNumber_1 = 20,
        AccountProfit_1 = 21,
        AccountServer_1 = 22,
        AccountStopoutLevel_1 = 23,
        AccountStopoutMode_1 = 24,
        GetLastError_1 = 25,
        IsStopped_1 = 26,
        UninitializeReason_1 = 27,
        MQLInfoInteger_1 = 28,
        MQLInfoString_1 = 29,
        MQLSetInteger_1 = 30,
        TerminalInfoInteger_1 = 31,
        TerminalInfoDouble_1 = 32,
        TerminalInfoString_1 = 33,
        Symbol_1 = 34,
        Period_1 = 35,
        Digits_1 = 36,
        Point_1 = 37,
        IsConnected_1 = 38,
        IsDemo_1 = 39,
        IsDllsAllowed_1 = 40,
        IsExpertEnabled_1 = 41,
        IsLibrariesAllowed_1 = 42,
        IsOptimization_1 = 43,
        IsTesting_1 = 44,
        IsTradeAllowed_1 = 45,
        IsTradeAllowed_2 = 46,
        IsTradeContextBusy_1 = 47,
        IsVisualMode_1 = 48,
        TerminalCompany_1 = 49,
        TerminalName_1 = 50,
        TerminalPath_1 = 51,
        MarketInfo_1 = 52,
        SymbolsTotal_1 = 53,
        SymbolName_1 = 54,
        SymbolSelect_1 = 55,
        RefreshRates_1 = 56,
        Bars_1 = 57,
        Bars_2 = 58,
        iBars_1 = 59,
        iBarShift_1 = 60,
        iClose_1 = 61,
        iHigh_1 = 62,
        iHighest_1 = 63,
        iLow_1 = 64,
        iLowest_1 = 65,
        iOpen_1 = 66,
        iTime_1 = 67,
        iVolume_1 = 68,
        ChartApplyTemplate_1 = 69,
        ChartSaveTemplate_1 = 70,
        ChartWindowFind_1 = 71,
        ChartWindowFind_2 = 72,
        ChartOpen_1 = 73,
        ChartFirst_1 = 74,
        ChartNext_1 = 75,
        ChartClose_1 = 76,
        ChartSymbol_1 = 77,
        ChartRedraw_1 = 78,
        ChartSetDouble_1 = 79,
        ChartSetInteger_1 = 80,
        ChartSetInteger_2 = 81,
        ChartSetString_1 = 82,
        ChartNavigate_1 = 83,
        ChartID_1 = 84,
        ChartIndicatorDelete_1 = 85,
        ChartIndicatorName_1 = 86,
        ChartIndicatorsTotal_1 = 87,
        ChartWindowOnDropped_1 = 88,
        ChartPriceOnDropped_1 = 89,
        ChartTimeOnDropped_1 = 90,
        ChartXOnDropped_1 = 91,
        ChartYOnDropped_1 = 92,
        ChartSetSymbolPeriod_1 = 93,
        ChartScreenShot_1 = 94,
        WindowBarsPerChart_1 = 95,
        WindowExpertName_1 = 96,
        WindowFind_1 = 97,
        WindowFirstVisibleBar_1 = 98,
        WindowHandle_1 = 99,
        WindowIsVisible_1 = 100,
        WindowOnDropped_1 = 101,
        WindowPriceMax_1 = 102,
        WindowPriceMin_1 = 103,
        WindowPriceOnDropped_1 = 104,
        WindowRedraw_1 = 105,
        WindowScreenShot_1 = 106,
        WindowTimeOnDropped_1 = 107,
        WindowsTotal_1 = 108,
        WindowXOnDropped_1 = 109,
        WindowYOnDropped_1 = 110,
        OrderClose_1 = 111,
        OrderCloseBy_1 = 112,
        OrderClosePrice_1 = 113,
        OrderCloseTime_1 = 114,
        OrderComment_1 = 115,
        OrderCommission_1 = 116,
        OrderDelete_1 = 117,
        OrderExpiration_1 = 118,
        OrderLots_1 = 119,
        OrderMagicNumber_1 = 120,
        OrderModify_1 = 121,
        OrderOpenPrice_1 = 122,
        OrderOpenTime_1 = 123,
        OrderPrint_1 = 124,
        OrderProfit_1 = 125,
        OrderSelect_1 = 126,
        OrderSend_1 = 127,
        OrdersHistoryTotal_1 = 128,
        OrderStopLoss_1 = 129,
        OrdersTotal_1 = 130,
        OrderSwap_1 = 131,
        OrderSymbol_1 = 132,
        OrderTakeProfit_1 = 133,
        OrderTicket_1 = 134,
        OrderType_1 = 135,
        SignalBaseGetDouble_1 = 136,
        SignalBaseGetInteger_1 = 137,
        SignalBaseGetString_1 = 138,
        SignalBaseSelect_1 = 139,
        SignalBaseTotal_1 = 140,
        SignalInfoGetDouble_1 = 141,
        SignalInfoGetInteger_1 = 142,
        SignalInfoGetString_1 = 143,
        SignalInfoSetDouble_1 = 144,
        SignalInfoSetInteger_1 = 145,
        SignalSubscribe_1 = 146,
        SignalUnsubscribe_1 = 147,
        GlobalVariableCheck_1 = 148,
        GlobalVariableTime_1 = 149,
        GlobalVariableDel_1 = 150,
        GlobalVariableGet_1 = 151,
        GlobalVariableName_1 = 152,
        GlobalVariableSet_1 = 153,
        GlobalVariablesFlush_1 = 154,
        GlobalVariableTemp_1 = 155,
        GlobalVariableSetOnCondition_1 = 156,
        GlobalVariablesDeleteAll_1 = 157,
        GlobalVariablesTotal_1 = 158,
        HideTestIndicators_1 = 159,
        IndicatorSetDouble_1 = 160,
        IndicatorSetDouble_2 = 161,
        IndicatorSetInteger_1 = 162,
        IndicatorSetInteger_2 = 163,
        IndicatorSetString_1 = 164,
        IndicatorSetString_2 = 165,
        IndicatorBuffers_1 = 166,
        IndicatorCounted_1 = 167,
        IndicatorDigits_1 = 168,
        IndicatorShortName_1 = 169,
        SetIndexArrow_1 = 170,
        SetIndexDrawBegin_1 = 171,
        SetIndexEmptyValue_1 = 172,
        SetIndexLabel_1 = 173,
        SetIndexShift_1 = 174,
        SetIndexStyle_1 = 175,
        SetLevelStyle_1 = 176,
        SetLevelValue_1 = 177,
        ObjectCreate_1 = 178,
        ObjectCreate_2 = 179,
        ObjectName_1 = 180,
        ObjectDelete_1 = 181,
        ObjectDelete_2 = 182,
        ObjectsDeleteAll_1 = 183,
        ObjectsDeleteAll_2 = 184,
        ObjectsDeleteAll_3 = 185,
        ObjectFind_1 = 186,
        ObjectFind_2 = 187,
        ObjectGetTimeByValue_1 = 188,
        ObjectGetValueByTime_1 = 189,
        ObjectMove_1 = 190,
        ObjectsTotal_1 = 191,
        ObjectsTotal_2 = 192,
        ObjectGetDouble_1 = 193,
        ObjectGetInteger_1 = 194,
        ObjectGetString_1 = 195,
        ObjectSetDouble_1 = 196,
        ObjectSetDouble_2 = 197,
        ObjectSetInteger_1 = 198,
        ObjectSetInteger_2 = 199,
        ObjectSetString_1 = 200,
        ObjectSetString_2 = 201,
        TextSetFont_1 = 202,
        ObjectDescription_1 = 203,
        ObjectGet_1 = 204,
        ObjectGetFiboDescription_1 = 205,
        ObjectGetShiftByValue_1 = 206,
        ObjectGetValueByShift_1 = 207,
        ObjectSet_1 = 208,
        ObjectSetFiboDescription_1 = 209,
        ObjectSetText_1 = 210,
        ObjectType_1 = 211,
        iAC_1 = 212,
        iAD_1 = 213,
        iADX_1 = 214,
        iAlligator_1 = 215,
        iAO_1 = 216,
        iATR_1 = 217,
        iBearsPower_1 = 218,
        iBands_1 = 219,
        iBullsPower_1 = 220,
        iCCI_1 = 221,
        iDeMarker_1 = 222,
        iEnvelopes_1 = 223,
        iForce_1 = 224,
        iFractals_1 = 225,
        iGator_1 = 226,
        iIchimoku_1 = 227,
        iBWMFI_1 = 228,
        iMomentum_1 = 229,
        iMFI_1 = 230,
        iMA_1 = 231,
        iOsMA_1 = 232,
        iMACD_1 = 233,
        iOBV_1 = 234,
        iSAR_1 = 235,
        iRSI_1 = 236,
        iRVI_1 = 237,
        iStdDev_1 = 238,
        iStochastic_1 = 239,
        iWPR_1 = 240,
        Print_1 = 241,
        SymbolInfoDouble_1 = 242,
        SymbolInfoInteger_1 = 243,
        SymbolInfoString_1 = 244,
        OrderGetOrderDefString_1 = 245,

        ObjectCreate_3 = 1001,
        iCustom_1 = 1000,
    }
}