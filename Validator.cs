﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ЛР_1_консоль
{
    public static class Validator
    {
        public static bool IsCorrectPrice(string price)
        {
            try
            {
                float temp = float.Parse(price);
                return true;
            }
            catch
            {
                return false;
            }
                

        }
    }
}
