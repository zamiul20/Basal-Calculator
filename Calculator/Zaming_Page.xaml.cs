namespace Calculator;

public partial class Zaming_Page : ContentPage
{
	public Zaming_Page()
	{
		InitializeComponent();
	}

    string selec = "None";

    string inbas = "< 10 T";
    string ansbas = "< 10 T";
    string innum = "0, 0";

    Basal leinbas = new Basal();
    Basal leoutbas = new Basal();

    public static char[] ParseNumbers(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return Array.Empty<char>();

        try
        {
            return input.Split(',')
                .SelectMany(s => s.Contains('.')
                    ? s.Split('.').Select(n => (char)(int.Parse(n.Trim()) + 48)).Concat(new[] { '.' })
                    : new[] { (char)(int.Parse(s.Trim()) + 48) }).ToArray();
        }
        catch
        {
            return ['w', 'h', 'y'];
        }

    }

    #region SET AND SELECT
    public void add_ente_n(object? sender, EventArgs e)
    {
        leinput.Text += 'ঋ';
    }
    public void add_ente_dis(object? sender, EventArgs e)
    {
        leinput.Text += 'গ';
    }
    public void add_ente_dn(object? sender, EventArgs e)
    {
        leinput.Text += 'দ';
    }
    public void add_ente_pr(object? sender, EventArgs e)
    {
        leinput.Text += "+ল";
    }
    public void add_ente_nr(object? sender, EventArgs e)
    {
        leinput.Text += "-ল";
    }
    public void add_ente_vel(object? sender, EventArgs e)
    {
        leinput.Text += 'স';
    }

    public void inbas_sel(object? sender, EventArgs e)
    {
        indicat_updat("Converting Base Selected");
        selec = "inbas";
        leinput.Text = inbas;
    }
    public void innum_sel(object? sender, EventArgs e)
    {
        indicat_updat("Input Value Selected");
        selec = "innum";
        leinput.Text = innum;
    }
    public void ansbas_sel(object? sender, EventArgs e)
    {
        indicat_updat("Casting Base Selected");
        selec = "outbas";
        leinput.Text = ansbas;
    }

    public void indicat_updat(string s)
    {
        indicat.Text = s;
    }


    public void sette(object? sender, EventArgs e)
    {
        switch (selec)
        {
            case "inbas":
                inbas = leinput.Text;
                break;
            case "innum":
                innum = String.Join("", ParseNumbers(leinput.Text));
                break;
            case "outbas":
                ansbas = leinput.Text;
                break;
        }
    }
    #endregion

    public void conver(object? sender, EventArgs e)
    {
        try
        {
            leinbas = new Basal();
            leoutbas = new Basal();

            if (ansbas.Length > 2)
            {
                string[] x = ansbas.Split(' ').Where(s => !string.IsNullOrEmpty(s)).ToArray();

                leoutbas.base_value = double.Parse(x[1]);

                if (x.Contains("ঋ"))
                    leoutbas.polar = 0;
                else if (x.Contains("দ"))
                    leoutbas.polar = 1;
                else leoutbas.polar = 2;

                if (x.Contains("+ল"))
                {
                    leoutbas.ripple = 0;
                    leoutbas.echo = int.Parse(x[x.IndexOf("+ল") + 1]);
                }
                else if (x.Contains("-ল"))
                {
                    leoutbas.ripple = 1;
                    leoutbas.echo = int.Parse(x[x.IndexOf("-ল") + 1]);
                }
                else leoutbas.ripple = 2;

                if (x.Contains("স"))
                {
                    leoutbas.velocity = double.Parse(x[x.IndexOf("স") + 1]);
                }
                leoutbas.disp();
                ansbas_but.Text = $"Casting Base - {leoutbas.display}";
            }
            else { indicat.Text = "Casting Base not defined"; }

            if (inbas.Length > 2)
            {
                string[] x = inbas.Split(' ').Where(s => !string.IsNullOrEmpty(s)).ToArray();

                leinbas.base_value = double.Parse(x[1]);

                if (x.Contains("ঋ"))
                    leinbas.polar = 0;
                else if (x.Contains("দ"))
                    leinbas.polar = 1;
                else leinbas.polar = 2;

                if (x.Contains("+ল"))
                {
                    leinbas.ripple = 0;
                    leinbas.echo = int.Parse(x[x.IndexOf("+ল") + 1]);
                }
                else if (x.Contains("-ল"))
                {
                    leinbas.ripple = 1;
                    leinbas.echo = int.Parse(x[x.IndexOf("-ল") + 1]);
                }
                else leinbas.ripple = 2;

                if (x.Contains("স"))
                {
                    leinbas.velocity = double.Parse(x[x.IndexOf("স") + 1]);
                }
                leinbas.disp();
                inbas_but.Text = $"Converting Base - {leinbas.display}";
            }
            else { indicat.Text = "Converting Base not defined"; }

            leinbas = new Basal(innum, leinbas.base_value, leinbas.polar, -8, leinbas.echo, leinbas.ripple, leinbas.velocity);

            innum_but.Text = "Input Value - <10T " + innum;

            string outout = "";
            decimal num = Decimal.Parse(innum);

            outout = leinbas.notobasten(num, leinbas.base_value, leinbas.velocity, 69);

            if (leinbas.polar != 2)
                leinbas.depolaris(outout, leinbas.base_value, leinbas.velocity, leinbas.polar, 69);

            if (leinbas.ripple != 2)
                leinbas.echor(outout, leinbas.ripple, leinbas.echo, 0);

            if (leoutbas.ripple != 2)
            {
                outout = leoutbas.unechor(leoutbas.echo, outout, leoutbas.ripple);
            }
            else
            {
                if (outout.Contains('জ'))
                {
                    outout.Trim(new char[] { 'জ' });
                }
            }
            if (leoutbas.polar != 2)
                num = leoutbas.polaris(outout, leoutbas.base_value, leoutbas.velocity, leoutbas.polar);
            else
                num = leoutbas.tobasten(outout, leoutbas.base_value, leoutbas.velocity);

            num_disp.Text = $"<10T {num}";
        }
        catch
        {
            num_disp.Text = "Unsupported or insufficient inputs";
        }
    }
}