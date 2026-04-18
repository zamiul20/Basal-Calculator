using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    internal class Basal
    {
        #region REQUIRED
        public static double expor(double num, double expo)
        {
            if (num < 0)
            {
                if (expo % 2 == 1)
                {
                    return (0 - Math.Pow(Math.Abs(num), expo));
                }
                else
                {
                    return (Math.Pow(Math.Abs(num), expo));
                }
            }
            else
            {
                return (Math.Pow(num, expo));
            }
        }
        public static string revstr(string stringInput)
        {
            char[] charArray = stringInput.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static int Cc(char n) { return (int)n - 48; }
        public static char Vc(int n) { return (char)(n + 48); }

        #endregion

        #region CONVERT TO AND FROM DENARY

        public decimal tobasten(string num, double bass, double velocity)
        {
            int po = 0;
            if (num[0] == '-')
            {
                po = 1;
                num = num.Substring(1);
            }
            decimal outout = 0;
            num = revstr(num);

            if (num.Contains('.'))
            {
                int pos = num.IndexOf('.');
                string left = num.Substring(0, pos);
                string right = num.Substring(pos + 1);

                for (int z = 0; z < left.Length; z++)
                {
                    outout += (decimal)expor(bass, (z * velocity)) * Cc(left[z]);
                }
                for (int z = 0; z < right.Length; z++)
                {
                    outout += (decimal)expor(bass, ((z + 1) * velocity)) * Cc(right[z]);
                }
            }
            else
            {
                for (int z = 0; z < num.Length; z++)
                {
                    outout += (decimal)expor(bass, (z * velocity)) * Cc(num[z]);
                }
            }

            if (po == 0) return outout;
            else return 0 - outout;
        }
        public string notobasten(decimal num, double bass, double velocity, int accuracy)
        {
            int statis = 0;
            if (bass < 1)
            {
                statis = 1;
                bass = 1 / bass;
            }

            int ceil = (int)(1 + Math.Floor(Math.Log((double)num, bass * velocity)));
            string outout = "";

            for (int z = 0; z < ceil; z++)
            {
                int q = ceil - (z + 1);
                decimal index = (decimal)expor(bass, (q * velocity));

                int t = (int)(Math.Floor(num / index));

                if (t >= 1)
                {
                    num -= (t * index);
                }
                outout += Vc(t);
            }

            if (num == 0)
            {
                if (statis == 0) return outout;
                else return $"0.{revstr(outout)}";
            }
            else
            {
                outout += '.';

                for (int z = 0; z < (accuracy - ceil); z++)
                {
                    if (num == 0)
                    {
                        return outout;
                    }
                    decimal index = 1M;
                    try
                    {
                        index = (decimal)expor(bass, (0 - (z + 1)) * velocity);
                    }
                    catch
                    {
                        break;
                    }

                    int t = (int)(Math.Floor(num / index));

                    if (t >= 1)
                    {
                        num -= (t * index);
                    }
                    outout += Vc(t);
                }
                if (statis == 0) return outout;
                else return revstr(outout);
            }
        }

        #endregion

        #region POLARITY

        public decimal polaris(string num, double bass, double velocity, int mod)
        {
            decimal outout = 0m;
            int l = num.Length;
            int q = l;

            for (int z = 0; z < l; z++)
            {
                if (num[z] == '.') continue;

                q--;
                if (z % 2 == mod)
                {
                    outout += (decimal)(Cc(num[z]) * expor(bass, (q * velocity)));
                }
                else
                {
                    outout -= (decimal)(Cc(num[z]) * expor(bass, (q * velocity)));
                }
            }

            return outout;
        }
        public string depolaris(string num, double bass, double velocity, int mod, int accuracy)
        {
            decimal abls = 0;

            string x = revstr(num);

            int z = 0;
            if (x.Contains('.'))
                z = x.IndexOf('.') - x.Length;

            for (int z_2 = 0; z_2 < x.Length; z_2++)
            {
                if (x[z_2] == '.') continue;

                z += 1;
                if (z % 2 == mod)
                {
                    if (x[z_2] != '0')
                    {
                        abls += (decimal)expor(bass, (z + 1) * velocity);
                        abls += (decimal)(bass - (2 * Cc(x[z_2])) * expor(bass, z * velocity));
                    }
                }
            }

            return notobasten(tobasten(num, bass, velocity) + abls, bass, velocity, accuracy);
        }
        #endregion

        #region ECHO

        public string unechor(int rip, string num, int mode)
        {
            string outout = "";
            int r = Math.Abs(rip);
            int nlen = num.Length - 1; int mid;

            try { mid = num.IndexOf('জ'); }
            catch { return "Error"; }

            string left = num.Substring(0, mid);
            string right = num.Substring(mid + 1);
            string fire = "I";
            int rx = right.Length;
            int lx = left.Length;
            int rount = rx;
            int lount = lx;

            if (rip > 0)
            {
                left = revstr(left);
            }
            else
            {
                right = revstr(right);
            }

            if (mode == 1) { fire = "780"; }

            for (int z = 0; z < nlen; z++)
            {
                if (fire == "I")
                {
                    for (int z_2 = 0; z_2 < r; z_2++)
                    {
                        if (rx == 0) { break; }

                        outout = $"{outout}{right[(rount - rx)]}";
                        rx--;
                    }
                    fire = "780";
                }
                else if (fire == "780")
                {
                    for (int z_2 = 0; z_2 < r; z_2++)
                    {
                        if (lx == 0) { break; }

                        outout = $"{outout}{right[(lount - lx)]}";
                        lx--;
                    }
                    fire = "I";
                }
            }

            return outout;
        }
        public string echor(string num, int mode, int rip, int uni)
        {
            int ripl = Math.Abs(rip);
            string left_arr = "";
            string right_arr = "";
            int x = num.Length;
            int count = x;
            string fire = "I";
            string placehold = "জ";

            if (uni == 1)
            {
                placehold = "&";
            }
            else if (uni == 2)
            {
                placehold = "";
            }

            while (x >= 0)
            {
                if (fire == "780") { fire = "I"; }
                else if (fire == "I") { fire = "780"; }
                else { return "Error"; }

                for (int z = 0; z < ripl; z++)
                {
                    if (fire == "I")
                    {

                        if (x == 0) { break; }
                        else
                        {
                            left_arr = $"{num[count - x]}{left_arr}";
                        }
                    }

                    else if (fire == "780")
                    {

                        if (x == 0) { break; }
                        else
                        {
                            right_arr = $"{right_arr}{num[count - x]}";
                        }
                    }
                    x--;
                }
                if (x == 0) { break; }
            }

            string outout = "";

            if (mode == 0)
            {
                if (rip > 0)
                {
                    outout = $"{left_arr}{placehold}{right_arr}";
                }
                else
                {
                    outout = $"{revstr(left_arr)}{placehold}{revstr(right_arr)}";
                }
            }
            else
            {
                if (rip > 0)
                {
                    outout = $"{right_arr}{placehold}{left_arr}";
                }
                else
                {
                    outout = $"{revstr(right_arr)}{placehold}{revstr(left_arr)}";
                }
            }

            return outout;
        }

        #endregion

        #region DISPLAY

        public string? disp()
        {
            string outout = $"<{base_value}";

            if (polar != 2)
            {
                if (polar == 0)
                {
                    outout += "ঋ";
                }
                else if (polar == 1)
                {
                    outout += "দ";
                }
            }
            if (discretion != 0)
            {
                outout += "গ";
            }
            if (echo != 2)
            {
                if (echo == 0)
                {
                    outout += $"+ল{ripple}";
                }
                if (echo == 1)
                {
                    outout += $"-ল{ripple}";
                }
            }
            if (velocity != 1)
            {
                outout += $"স{velocity}";
            }

            display = outout + "T";

            return display;
        }

        #endregion

        #region ATTRIBUTES
        public int type = 1;
        public int polar = 2;
        public int discretion = 0;
        public int echo = 2;
        public int ripple = 0;
        public double velocity = 1;
        public int po = 0;

        public double base_value = 10;

        public string? display = "<10T";

        public string? number = "0";
        public decimal value = 0;
        #endregion

        public Basal() { }

        public Basal(
            string num,
            double bass,
            int pol,
            int dis,
            int eco,
            int rip,
            double vel
            )
        {
            number = num;
            base_value = bass;
            polar = pol;
            discretion = dis;
            echo = eco;
            ripple = rip;
            velocity = vel;

            if (ripple != 2)
            {
                num = unechor(rip, num, echo);
            }
            if (pol != 2)
            {
                value = polaris(num, bass, vel, pol);
            }
            else
            {
                value = tobasten(num, bass, vel);
            }
        }

        public Basal(
            double bass,
            int pol,
            int dis,
            int eco,
            int rip,
            double vel
            )
        {
            base_value = bass;
            polar = pol;
            discretion = dis;
            echo = eco;
            ripple = rip;
            velocity = vel;
        }

        public Basal(
            decimal num,
            double bass,
            int pol,
            int dis,
            int eco,
            int rip,
            double vel
            )
        {
            value = num;
            base_value = bass;
            polar = pol;
            discretion = dis;
            echo = eco;
            ripple = rip;
            velocity = vel;

            number = notobasten(num, bass, vel, 69);

            if (polar != 2)
            {
                number = depolaris(number, bass, vel, pol, 69);
            }

            if (ripple != 2)
            {
                number = echor(number, echo, rip, 0);
            }
        }
    }
}
