﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace UniconGS.UI.Schedule
{
    [XmlRoot("Graphic", Namespace = "", IsNullable = false), Serializable]
    public class GraphicValue
    {
        [XmlElement]
        public List<GraphicMonth> Month { get; set; }
        [XmlElement]
        public GraphicYearSaving YearSaving { get; set; }
        [XmlElement]
        public GraphicMonthSaveing MonthSaving { get; set; }
        [XmlElement]
        public bool IsSavingTurnOn { get; set; }
        public GraphicValue(List<GraphicMonth> months, GraphicYearSaving yearSaving)
        {
            this.Month = months;
            this.YearSaving = yearSaving;
            this.MonthSaving = new GraphicMonthSaveing();
        }
        /*Заглушка на экономию*/
        public GraphicValue(List<GraphicMonth> months, GraphicYearSaving yearSaving, GraphicMonthSaveing monthSaving)
        {
            this.Month = months;
            this.YearSaving = yearSaving;
            /*Заглушка на экономию*/
            this.MonthSaving = monthSaving;
        }
        public GraphicValue(List<GraphicMonth> months)
        {
            this.Month = months;
            this.YearSaving = new GraphicYearSaving(0, 0, 0, 0);///1111
            /*Заглушка на экономию*/
            this.MonthSaving = new GraphicMonthSaveing();
        }
        public GraphicValue()
        { }
        public ushort[] GetValue()
        {
            var tmp = new List<ushort>();
            foreach (var month in this.Month)
            {


                if (month.MonthName.Contains("Январь"))
                {
                    
                }

                foreach (var day in month.Days)
                {
                    tmp.Add(BitConverter.ToUInt16(new byte[2] { Convert.ToByte(day.TurnOffTime.Minute), Convert.ToByte(day.TurnOffTime.Hour) }, 0));
                    tmp.Add(BitConverter.ToUInt16(new byte[2] { Convert.ToByte(day.TurnOnTime.Minute), Convert.ToByte(day.TurnOnTime.Hour) }, 0));
                }
                if (this.IsSavingTurnOn)
                {
                    /*Заглушка для экономии*/
                    tmp.Add(BitConverter.ToUInt16(new byte[2] { Convert.ToByte(/*month*/this.MonthSaving.TurnOffTime.Minute), Convert.ToByte(this.MonthSaving.TurnOffTime.Hour) }, 0));
                    tmp.Add(BitConverter.ToUInt16(new byte[2] { Convert.ToByte(/*month*/this.MonthSaving.TurnOnTime.Minute), Convert.ToByte(this.MonthSaving.TurnOnTime.Hour) },0));
                }
                else
                {
                    tmp.Add(0); tmp.Add(0);
                }
            }
            if (this.IsSavingTurnOn)
            {
                tmp.Add(BitConverter.ToUInt16(new byte[2] { Convert.ToByte(this.YearSaving.TurnOffDay), Convert.ToByte(this.YearSaving.TurnOffMonth) },0));
                tmp.Add(BitConverter.ToUInt16(new byte[2] { Convert.ToByte(this.YearSaving.TurnOnDay), Convert.ToByte(this.YearSaving.TurnOnMonth) }, 0));
            }
            else
            {
                tmp.Add(0); tmp.Add(0);
            }
            return tmp.ToArray();
        }

        public static GraphicValue SetValue(List<GraphicMonth> months, ushort[] value)
        {
            GraphicValue tmp = new GraphicValue(months);
            int tmpCounter = 0;
            foreach (var month in tmp.Month)
            {
                foreach (var day in month.Days)
                {
                    var timeValue = BitConverter.GetBytes(value[tmpCounter]);
                    day.TurnOffTime.Hour = timeValue[1];
                    day.TurnOffTime.Minute = timeValue[0];
                    timeValue = BitConverter.GetBytes(value[tmpCounter + 1]);
                    day.TurnOnTime.Hour = timeValue[1];
                    day.TurnOnTime.Minute = timeValue[0];
                    tmpCounter = tmpCounter + 2;
                }
                var savingValue = BitConverter.GetBytes(value[tmpCounter]);
                month.MonthSaving.TurnOffTime.Hour = savingValue[1];
                month.MonthSaving.TurnOffTime.Minute = savingValue[0];
                savingValue = BitConverter.GetBytes(value[tmpCounter + 1]);
                month.MonthSaving.TurnOnTime.Hour = savingValue[1];
                month.MonthSaving.TurnOnTime.Minute = savingValue[0];
                tmpCounter = tmpCounter + 2;
            }
            var yearSavingValue = BitConverter.GetBytes(value[tmpCounter]);
            if (yearSavingValue[0] == 0)
            {
                tmp.IsSavingTurnOn = false;
                tmp.YearSaving.TurnOffMonth = 1;
                tmp.YearSaving.TurnOffDay = 1;
                tmp.YearSaving.TurnOnDay = 1;
                tmp.YearSaving.TurnOnMonth = 1;
                /*Заглушка для экономии*/
                tmp.MonthSaving = new GraphicMonthSaveing();
            }
            else
            {
                tmp.IsSavingTurnOn = true ;
                tmp.YearSaving.TurnOffMonth = yearSavingValue[1];
                tmp.YearSaving.TurnOffDay = yearSavingValue[0];
                yearSavingValue = BitConverter.GetBytes(value[tmpCounter + 1]);
                tmp.YearSaving.TurnOnMonth = yearSavingValue[1];
                tmp.YearSaving.TurnOnDay = yearSavingValue[0];
                /*Заглушка для экономии*/
                tmp.MonthSaving = tmp.Month[0].MonthSaving;
            }
            return tmp;
        }
    }
}