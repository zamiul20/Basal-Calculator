namespace Calculator;

public partial class Calc_Page : ContentPage
{
    #region VARIABLES
    string selec = "780";

    string firbas = "< 10 T"; string firnum = "0,0"; string firnum_disp = "";
    string secbas = "< 10 T"; string secnum = "0,0"; string secnum_disp = "";

    string ansbas = "< 10 T"; string? ansnum = "No Calculation Yet"; string ansnum_disp = "";

    Basal[] basar = [new Basal(), new Basal(), new Basal()];

    #endregion

    public Calc_Page()
	{
		InitializeComponent();
	}
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

    public void indicator(string indicati)
    {
        indicat.Text = indicati;
    }

    #region SELECT_SET
    public void firbas_selec(object? sender, EventArgs e)
	{
        selec = "firbas";
        indicator("First Base Selected");
        leinput.Text = firbas;
	}
    public void secbas_selec(object? sender, EventArgs e)
    {
        selec = "secbas";
        indicator("Second Base Selected");
        leinput.Text = secbas;
    }
    public void ansbas_selec(object? sender, EventArgs e)
    {
        selec = "ansbas";
        indicator("Answer Base Selected");
        leinput.Text = ansbas;
    }
    public void firnum_selec(object? sender, EventArgs e)
    {
        selec = "firnum";
        indicator("First Number Selected");
        num_disp.Text = firnum_disp;
        leinput.Text = firnum;
    }
    public void secnum_selec(object? sender, EventArgs e)
    {
        selec = "secnum";
        indicator("Second number Selected");
        num_disp.Text = secnum_disp;
        leinput.Text = secnum;
    }
    public void ansnum_selec(object? sender, EventArgs e)
    {
        selec = "ansnum";
        indicator("Answer number Selected");
        num_disp.Text = ansnum_disp;
        leinput.Text = ansnum;
    }

    public void sette(object? sender, EventArgs e)
    {
        switch (selec)
        {
            case "firbas":
                firbas = leinput.Text;
                break;

            case "secbas":
                secbas = leinput.Text;
                break;

            case "firnum":
                firnum_disp = leinput.Text;
                firnum = String.Join("", ParseNumbers(leinput.Text));
                break;

            case "secnum":
                secnum_disp = leinput.Text;
                secnum = String.Join("", ParseNumbers(leinput.Text));
                break;

            case "ansbas":
                ansbas = leinput.Text;
                break;
        }
    }

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
    #endregion

    #region OPERATIONS

    public void makbas()
    {
        basar[0] = new Basal();
        basar[1] = new Basal();
        basar[2] = new Basal();

        if (ansbas.Length > 2)
        {
            string[] x = ansbas.Split(' ').Where(s => !string.IsNullOrEmpty(s)).ToArray();

            basar[2].base_value = double.Parse(x[1]);

            if (x.Contains("ঋ"))
                basar[2].polar = 0;
            else if (x.Contains("দ"))
                basar[2].polar = 1;
            else basar[2].polar = 2;

            if (x.Contains("+ল"))
            {
                basar[2].echo = 0;
                basar[2].ripple = int.Parse(x[x.IndexOf("+ল") + 1]);
            }
            else if (x.Contains("-ল"))
            {
                basar[2].echo = 1;
                basar[2].ripple = int.Parse(x[x.IndexOf("-ল") + 1]);
            }
            else basar[2].echo = 2;

            if (x.Contains("স"))
            {
                basar[2].velocity = double.Parse(x[x.IndexOf("স") + 1]);
            }
            basar[2].disp();
            ansbas_but.Text = $"Answer Base - {basar[2].display}";
        }
        else { indicat.Text = "Answer Base not defined"; }

        if (firbas.Length > 2)
        {
            string[] x = firbas.Substring(0).Split(' ').Where(s => !string.IsNullOrEmpty(s)).ToArray();

            basar[0].base_value = double.Parse(x[1]);

            if (x.Contains("ঋ"))
                basar[0].polar = 0;
            else if (x.Contains("দ"))
                basar[0].polar = 1;
            else basar[0].polar = 2;

            if (x.Contains("+ল"))
            {
                basar[0].echo = 0;
                basar[0].ripple = int.Parse(x[x.IndexOf("+ল") + 1]);
            }
            else if (x.Contains("-ল"))
            {
                basar[0].echo = 1;
                basar[0].ripple = int.Parse(x[x.IndexOf("-ল") + 1]);
            }
            else basar[0].echo = 2;

            if (x.Contains("স"))
            {
                basar[0].velocity = double.Parse(x[x.IndexOf("স") + 1]);
            }
            basar[0].disp();
            firbas_but.Text = $"First Base - {basar[0].display}";
        }
        else { indicat.Text = "First Base not defined"; }

        if (secbas.Length > 2)
        {
            string[] x = secbas.Substring(0).Split(' ').Where(s => !string.IsNullOrEmpty(s)).ToArray();

            basar[1].base_value = double.Parse(x[1]);

            if (x.Contains("ঋ"))
                basar[1].polar = 0;
            else if (x.Contains("দ"))
                basar[1].polar = 1;
            else basar[1].polar = 2;

            if (x.Contains("+ল"))
            {
                basar[1].echo = 0;
                basar[1].ripple = int.Parse(x[x.IndexOf("+ল") + 1]);
            }
            else if (x.Contains("-ল"))
            {
                basar[1].echo = 1;
                basar[1].ripple = int.Parse(x[x.IndexOf("-ল") + 1]);
            }
            else basar[1].echo = 2;

            if (x.Contains("স"))
            {
                basar[1].velocity = double.Parse(x[x.IndexOf("স") + 1]);
            }
            basar[1].disp();
            secbas_but.Text = $"Second Base - {basar[1].display}";
        }
        else { indicat.Text = "Second Base not defined"; }
    }

    public void setbas()
    {
        makbas();

        basar[0] = new Basal(firnum, basar[0].base_value, basar[0].polar, 0, basar[0].echo, basar[0].ripple, basar[0].velocity);
        basar[1] = new Basal(secnum, basar[1].base_value, basar[1].polar, 1, basar[1].echo, basar[1].ripple, basar[1].velocity);

        firnum_but.Text = "First Number - <10T " + basar[0].value.ToString();
        secnum_but.Text = "Second Number - <10T " + basar[1].value.ToString();

        basar[2] = new Basal(basar[2].base_value, basar[2].polar, -8, basar[2].echo, basar[2].ripple, basar[2].velocity);
    }

    public void giv_ans()
    {
        ansnum_but.Text = "Answer Number - <10T " + basar[2].value.ToString();

        Basal tmp = new Basal();

        var po = 0;
        if (basar[2].value > 0)
        {
            basar[2].value = Math.Abs(basar[2].value);
            po = 1;
        }

        basar[2].number = tmp.notobasten(basar[2].value, basar[2].base_value, basar[2].velocity, 69);
        
        if (basar[2].polar != 2) 
            basar[2].number = tmp.depolaris(basar[2].number, basar[2].base_value, basar[2].velocity, basar[2].polar, 69);
        if (basar[2].ripple != 2) 
            basar[2].number = tmp.echor(basar[2].number, basar[2].ripple, basar[2].echo, 0);        

        if (po == 0)
            ansnum_disp = basar[2].number + " ";
        else
            ansnum_disp = "- " + basar[2].number + " ";

        ansnum = ansnum_disp;
    }

    public void add_but(object? sender, EventArgs e)
    {
        setbas();
        basar[2].value = basar[0].value + basar[1].value;
        giv_ans();
    }
    public void sub_but(object? sender, EventArgs e)
    {
        setbas();
        basar[2].value = basar[0].value - basar[1].value;
        giv_ans();
    }
    public void mul_but(object? sender, EventArgs e)
    {
        setbas();
        basar[2].value = basar[0].value * basar[1].value;
        giv_ans();
    }
    public void div_but(object? sender, EventArgs e)
    {
        setbas();
        basar[2].value = basar[0].value / basar[1].value;
        giv_ans();
    }
    public void pow_but(object? sender, EventArgs e)
    {
        setbas();
        basar[2].value = Convert.ToDecimal(Basal.expor(decimal.ToDouble(basar[0].value), decimal.ToDouble(basar[1].value)));
        giv_ans();
    }
    public void mulpow_byE_but(object? sender, EventArgs e)
    {
        setbas();
        basar[2].value = basar[0].value * Convert.ToDecimal(Basal.expor(Math.E, decimal.ToDouble(basar[1].value)));
        giv_ans();
    }
    
    #endregion

}
