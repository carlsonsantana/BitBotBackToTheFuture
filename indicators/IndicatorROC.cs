﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class IndicatorROC:IndicatorBase, IIndicator
    {
        public IndicatorROC()
        {
            this.indicator = this;
        this.period = 9;
        }
        public string getName()
        {
            return "ROC";
        }

    public void setPeriod(int period)
    {
        this.period = period;

    }
    public double getResult()
        {
            return this.result;
        }

        public double getResult2()
        {
            return this.result2;
        }

        public Operation GetOperation(double[] arrayPriceOpen, double[] arrayPriceClose, double[] arrayPriceLow, double[] arrayPriceHigh, double[] arrayVolume)
        {
            try
            {
                int outBegidx, outNbElement;
                double[] arrayresultTA = new double[arrayPriceClose.Length];
                arrayresultTA = new double[arrayPriceClose.Length];
            TicTacTec.TA.Library.Core.Roc(0, arrayPriceClose.Length - 1, arrayPriceClose, this.period, out outBegidx, out outNbElement, arrayresultTA);
                double value = arrayresultTA[outNbElement - 1];
                this.result = value;
                if (value > 0)
                    return Operation.buy;
                if (value < 0)
                    return Operation.sell;
                return Operation.nothing;
            }
            catch
            {
                return Operation.nothing;
            }
        }
    }
