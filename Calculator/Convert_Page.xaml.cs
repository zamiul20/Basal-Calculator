namespace Calculator;

public partial class Convert_Page : ContentPage
{
	public Convert_Page()
	{
		InitializeComponent();
	}
    string selec = "None";

    string inbas = "< 10 T";
    string ansbas = "< 10 T";
    string innum = "0, 0";
    string innum_d = "00";

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
        indicat_updat("Input Base Selected");
        selec = "inbas";
        leinput.Text = inbas;
    }
    public void innum_sel(object? sender, EventArgs e)
    {
        indicat_updat("Input Number Selected");
        selec = "innum";
        leinput.Text = innum;
    }
    public void ansbas_sel(object? sender, EventArgs e)
    {
        indicat_updat("Output Base Selected");
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
                innum_d = leinput.Text;
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
                leoutbas.echo = 0;
                leoutbas.ripple = int.Parse(x[x.IndexOf("+ল") + 1]);
            }
            else if (x.Contains("-ল"))
            {
                leoutbas.echo = 1;
                leoutbas.ripple = int.Parse(x[x.IndexOf("-ল") + 1]);
            }
            else leoutbas.echo = 2;

            if (x.Contains("স"))
            {
                leoutbas.velocity = double.Parse(x[x.IndexOf("স") + 1]);
            }
            leoutbas.disp();
            ansbas_but.Text = $"Output Base - {leoutbas.display}";
        }
        else { indicat.Text = "Output Base not defined"; }

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
                leinbas.echo = 0;
                leinbas.ripple = int.Parse(x[x.IndexOf("+ল") + 1]);
            }
            else if (x.Contains("-ল"))
            {
                leinbas.echo = 1;
                leinbas.ripple = int.Parse(x[x.IndexOf("-ল") + 1]);
            }
            else leinbas.echo = 2;

            if (x.Contains("স"))
            {
                leinbas.velocity = double.Parse(x[x.IndexOf("স") + 1]);
            }
            leinbas.disp();
            inbas_but.Text = $"Input Base - {leinbas.display}";
        }
        else { indicat.Text = "Input Base not defined"; }

        leinbas = new Basal(innum, leinbas.base_value, leinbas.polar, -8, leinbas.echo, leinbas.ripple, leinbas.velocity);

        innum_but.Text = "Input Number - <10T " + leinbas.value.ToString();

        Basal tmp = new Basal();
        leoutbas.number = tmp.notobasten(leinbas.value, leoutbas.base_value, leoutbas.velocity, 69);

        if (leoutbas.polar != 2)
            leoutbas.number = tmp.depolaris(leoutbas.number, leoutbas.base_value, leoutbas.velocity, leoutbas.polar, 69);
        if (leoutbas.ripple != 2)
            leoutbas.number = tmp.echor(leoutbas.number, leoutbas.ripple, leoutbas.echo, 0);

        string outout = " = ";

        for (int z = 0; z < leoutbas.number.Length; z++)
        {
            outout += ((int)leoutbas.number[z] - 48).ToString() + " ";
        }

        num_disp.Text = $"Output Number in {leoutbas.display} ⟶" + leoutbas.number + outout;
    }

}
