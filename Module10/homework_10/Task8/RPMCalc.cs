using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading;

namespace homework_10.Task8
{
    public static class RPMCalc
    {
        public static decimal CalculateRPN(string rpn)
        {
            if(string.IsNullOrEmpty(rpn)) throw new ArgumentNullException();
            string[] strSplit = rpn.Split(' ');
            Stack<decimal> stack = new Stack<decimal>();
            decimal tmpNum = decimal.Zero;

            foreach (string str in strSplit)
            {
                if (decimal.TryParse(str, out tmpNum))
                {
                    stack.Push(tmpNum);
                }
                else
                {
                    switch (str)
                    {
                        case "^":
                        case "pow":
                            {
                                tmpNum = stack.Pop();
                                stack.Push((decimal)Math.Pow((double)stack.Pop(), (double)tmpNum));
                                break;
                            }
                        case "ln":
                            {
                                stack.Push((decimal)Math.Log((double)stack.Pop(), Math.E));
                                break;
                            }
                        case "sqrt":
                            {
                                stack.Push((decimal)Math.Sqrt((double)stack.Pop()));
                                break;
                            }
                        case "*":
                            {
                                stack.Push(stack.Pop() * stack.Pop());
                                break;
                            }
                        case "/":
                            {
                                tmpNum = stack.Pop();
                                stack.Push(stack.Pop() / tmpNum);
                                break;
                            }
                        case "+":
                            {
                                stack.Push(stack.Pop() + stack.Pop());
                                break;
                            }
                        case "-":
                            {
                                tmpNum = stack.Pop();
                                stack.Push(stack.Pop() - tmpNum);
                                break;
                            }
                    }
                }
            }

            return stack.Pop();
        }
    }

}