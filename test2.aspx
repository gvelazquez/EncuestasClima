<%@ Page Language="VB" AutoEventWireup="false" CodeFile="test2.aspx.vb" Inherits="test2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <!--<link rel="stylesheet" type="text/css" href="scroll.css"/>-->
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        table
        {
            border: 1px solid #ccc;
            border-collapse: collapse;
            width: 100%;
        }
        table th
        {
            background-color: #F7F7F7;
            color: #333;
            font-weight: normal;
        }
        table th, table td
        {
            border: 1px solid #ccc;
        }
    </style>    
</head>
<body>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="Scripts/ScrollableTablePlugin_1.0_min.js" type="text/javascript"></script>
    <script type="text/javascript">
    $(function () {
        $('#Table1').Scrollable({
            ScrollHeight: 100
        });
    });
    </script>
    
<table cellspacing="0" rules="all" border="1" id="Table1" style="border-collapse: collapse;">
	<tr>
		<td></td>
		<td>
			<label>no</label>
		</td>
		<td>
			<label>casi nunca</label>
		</td>
		<td>
			<label>frecc</label>
		</td>
		<td>
			<label>si</label>
		</td>
	</tr>
    <tr>
	    <td>1 Me siento contento de trabajar en esta empresa</td>
	    <td>
		    <span title="No">
			    <input id="ctl03" type="radio" name="1" value="ctl03" />
		    </span>
	    </td>
	    <td>
		    <span title="Casi Nunca">
			    <input id="ctl04" type="radio" name="1" value="ctl04" />
		    </span>
	    </td>
	    <td>
		    <span title="Frec.">
			    <input id="ctl05" type="radio" name="1" value="ctl05" />
		    </span>
	    </td>
	    <td>
		    <span title="Si">
			    <input id="ctl06" type="radio" name="1" value="ctl06" />
		    </span>
	    </td>
	</tr>
	<tr>
		    <td>2 Me gusta el trabajo que desempeño</td>
		    <td>
			    <span title="No">
				    <input id="ctl07" type="radio" name="2" value="ctl07" />
			    </span>
		    </td>
		    <td>
			    <span title="Casi Nunca">
				    <input id="ctl08" type="radio" name="2" value="ctl08" />
			    </span>
		    </td>
		    <td>
			    <span title="Frec.">
				    <input id="ctl09" type="radio" name="2" value="ctl09" />
			    </span>
		    </td>
		    <td>
			    <span title="Si">
				    <input id="ctl10" type="radio" name="2" value="ctl10" />
			    </span>
		    </td>
    </tr>
	<tr>
		    <td>3 Me quedaré en esta Empresa aunque me ofrezcan el mismo sueldo en otra</td>
		    <td>
			    <span title="No">
				    <input id="ctl11" type="radio" name="197" value="ctl11" />
			    </span>
		    </td>
		    <td>
			    <span title="Casi Nunca">
				    <input id="ctl12" type="radio" name="197" value="ctl12" />
			    </span>
		    </td>
		    <td>
			    <span title="Frec.">
				    <input id="ctl13" type="radio" name="197" value="ctl13" />
			    </span>
		    </td>
		    <td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl14" type="radio" name="197" value="ctl14" /></span></td></tr><tr><td width=75%>4 Tengo el equipo y material necesario para llevar a cabo mi trabajo</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl15" type="radio" name="4" value="ctl15" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl16" type="radio" name="4" value="ctl16" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl17" type="radio" name="4" value="ctl17" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl18" type="radio" name="4" value="ctl18" /></span></td></tr><tr><td width=75%>5 En mi departamento se promueve que todos realicemos el trabajo excelente</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl19" type="radio" name="8" value="ctl19" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl20" type="radio" name="8" value="ctl20" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl21" type="radio" name="8" value="ctl21" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl22" type="radio" name="8" value="ctl22" /></span></td></tr><tr><td width=75%>6 Si realizo bien mi trabajo me sentiré seguro de permanecer en la Empresa</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl23" type="radio" name="178" value="ctl23" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl24" type="radio" name="178" value="ctl24" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl25" type="radio" name="178" value="ctl25" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl26" type="radio" name="178" value="ctl26" /></span></td></tr><tr><td width=75%>7 ¿El area de trabajo es adecuada para el trabajo que desempeño?</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl27" type="radio" name="200" value="ctl27" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl28" type="radio" name="200" value="ctl28" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl29" type="radio" name="200" value="ctl29" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl30" type="radio" name="200" value="ctl30" /></span></td></tr><tr><td width=75%>8 Tengo tiempo suficiente para disfrutar a mi familia después del trabajo</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl31" type="radio" name="108" value="ctl31" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl32" type="radio" name="108" value="ctl32" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl33" type="radio" name="108" value="ctl33" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl34" type="radio" name="108" value="ctl34" /></span></td></tr><tr><td width=75%>9 El lugar donde trabajo está bien ventilado e iluminado</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl35" type="radio" name="12" value="ctl35" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl36" type="radio" name="12" value="ctl36" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl37" type="radio" name="12" value="ctl37" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl38" type="radio" name="12" value="ctl38" /></span></td></tr><tr><td width=75%>10 Me encuentro a gusto en mi departamento</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl39" type="radio" name="15" value="ctl39" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl40" type="radio" name="15" value="ctl40" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl41" type="radio" name="15" value="ctl41" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl42" type="radio" name="15" value="ctl42" /></span></td></tr><tr><td width=75%>11 En esta Empresa me tratan bien</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl43" type="radio" name="181" value="ctl43" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl44" type="radio" name="181" value="ctl44" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl45" type="radio" name="181" value="ctl45" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl46" type="radio" name="181" value="ctl46" /></span></td></tr><tr><td width=75%>12 En esta Empresa tratan bien a los Asociados</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl47" type="radio" name="179" value="ctl47" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl48" type="radio" name="179" value="ctl48" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl49" type="radio" name="179" value="ctl49" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl50" type="radio" name="179" value="ctl50" /></span></td></tr><tr><td width=75%>13 Mi jefe me informa sobre mi desempeño en el trabajo</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl51" type="radio" name="19" value="ctl51" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl52" type="radio" name="19" value="ctl52" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl53" type="radio" name="19" value="ctl53" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl54" type="radio" name="19" value="ctl54" /></span></td></tr><tr><td width=75%>14 Conozco compañeros que han sido promovidos en el Grupo</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl55" type="radio" name="20" value="ctl55" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl56" type="radio" name="20" value="ctl56" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl57" type="radio" name="20" value="ctl57" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl58" type="radio" name="20" value="ctl58" /></span></td></tr><tr><td width=75%>15 Mi Jefe me comunica oportunamente acerca de lo que sucede en la Empresa</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl59" type="radio" name="180" value="ctl59" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl60" type="radio" name="180" value="ctl60" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl61" type="radio" name="180" value="ctl61" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl62" type="radio" name="180" value="ctl62" /></span></td></tr><tr><td width=75%>16 ¿El proceso de comunicación con mis compañeros es eficiente?</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl63" type="radio" name="199" value="ctl63" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl64" type="radio" name="199" value="ctl64" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl65" type="radio" name="199" value="ctl65" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl66" type="radio" name="199" value="ctl66" /></span></td></tr><tr><td width=75%>17 Recibo información para mi trabajo en juntas o reuniones</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl67" type="radio" name="23" value="ctl67" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl68" type="radio" name="23" value="ctl68" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl69" type="radio" name="23" value="ctl69" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl70" type="radio" name="23" value="ctl70" /></span></td></tr><tr><td width=75%>18 Conozco cuál es la misión de Milenium</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl71" type="radio" name="25" value="ctl71" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl72" type="radio" name="25" value="ctl72" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl73" type="radio" name="25" value="ctl73" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl74" type="radio" name="25" value="ctl74" /></span></td></tr><tr><td width=75%>19 Conozco cuál es la visión de Milenium</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl75" type="radio" name="26" value="ctl75" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl76" type="radio" name="26" value="ctl76" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl77" type="radio" name="26" value="ctl77" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl78" type="radio" name="26" value="ctl78" /></span></td></tr><tr><td width=75%>20 Conozco cuáles son los valores de Milenium</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl79" type="radio" name="27" value="ctl79" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl80" type="radio" name="27" value="ctl80" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl81" type="radio" name="27" value="ctl81" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl82" type="radio" name="27" value="ctl82" /></span></td></tr><tr><td width=75%>21 Conozco las instalaciones de la Empresa</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl83" type="radio" name="190" value="ctl83" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl84" type="radio" name="190" value="ctl84" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl85" type="radio" name="190" value="ctl85" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl86" type="radio" name="190" value="ctl86" /></span></td></tr><tr><td width=75%>22 El Director de área ha platicado o conversado conmigo</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl87" type="radio" name="187" value="ctl87" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl88" type="radio" name="187" value="ctl88" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl89" type="radio" name="187" value="ctl89" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl90" type="radio" name="187" value="ctl90" /></span></td></tr><tr><td width=75%>23 Mi jefe directo tiene una buena relación de trabajo conmigo</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl91" type="radio" name="30" value="ctl91" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl92" type="radio" name="30" value="ctl92" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl93" type="radio" name="30" value="ctl93" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl94" type="radio" name="30" value="ctl94" /></span></td></tr><tr><td width=75%>24 Mi jefe directo me da instrucciones claras sobre mi trabajo</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl95" type="radio" name="32" value="ctl95" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl96" type="radio" name="32" value="ctl96" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl97" type="radio" name="32" value="ctl97" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl98" type="radio" name="32" value="ctl98" /></span></td></tr><tr><td width=75%>25 Mi jefe me apoya y me ayuda a tomar decisiones</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl99" type="radio" name="34" value="ctl99" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl100" type="radio" name="34" value="ctl100" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl101" type="radio" name="34" value="ctl101" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl102" type="radio" name="34" value="ctl102" /></span></td></tr><tr><td width=75%>26 Cuando hago bien un trabajo, mi jefe me felicita</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl103" type="radio" name="35" value="ctl103" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl104" type="radio" name="35" value="ctl104" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl105" type="radio" name="35" value="ctl105" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl106" type="radio" name="35" value="ctl106" /></span></td></tr><tr><td width=75%>27 Mi jefe es honesto con la Empresa</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl107" type="radio" name="183" value="ctl107" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl108" type="radio" name="183" value="ctl108" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl109" type="radio" name="183" value="ctl109" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl110" type="radio" name="183" value="ctl110" /></span></td></tr><tr><td width=75%>28 Cuando mi jefe me llama la atención lo hace con respeto</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl111" type="radio" name="37" value="ctl111" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl112" type="radio" name="37" value="ctl112" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl113" type="radio" name="37" value="ctl113" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl114" type="radio" name="37" value="ctl114" /></span></td></tr><tr><td width=75%>29 En esta Empresa  nos tratan a todos por igual, nos tratan parejo</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl115" type="radio" name="182" value="ctl115" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl116" type="radio" name="182" value="ctl116" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl117" type="radio" name="182" value="ctl117" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl118" type="radio" name="182" value="ctl118" /></span></td></tr><tr><td width=75%>30 Si me capacito tendré posibilidades de progresar en esta empresa.</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl119" type="radio" name="39" value="ctl119" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl120" type="radio" name="39" value="ctl120" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl121" type="radio" name="39" value="ctl121" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl122" type="radio" name="39" value="ctl122" /></span></td></tr><tr><td width=75%>31 Las personas que tienen un buen desempeño tienen oportunidades de subir de puesto en el Grupo.</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl123" type="radio" name="78" value="ctl123" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl124" type="radio" name="78" value="ctl124" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl125" type="radio" name="78" value="ctl125" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl126" type="radio" name="78" value="ctl126" /></span></td></tr><tr><td width=75%>32 Considero que las personas que mejoran de puesto o son promocionadas se lo han ganado?</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl127" type="radio" name="201" value="ctl127" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl128" type="radio" name="201" value="ctl128" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl129" type="radio" name="201" value="ctl129" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl130" type="radio" name="201" value="ctl130" /></span></td></tr><tr><td width=75%>33 En este hotel existen buenas relaciones de trabajo entre compañeros</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl131" type="radio" name="44" value="ctl131" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl132" type="radio" name="44" value="ctl132" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl133" type="radio" name="44" value="ctl133" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl134" type="radio" name="44" value="ctl134" /></span></td></tr><tr><td width=75%>34 En la Empresa los problemas se solucionan de manera adecuda </td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl135" type="radio" name="185" value="ctl135" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl136" type="radio" name="185" value="ctl136" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl137" type="radio" name="185" value="ctl137" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl138" type="radio" name="185" value="ctl138" /></span></td></tr><tr><td width=75%>35 En la Empresa existen buenas relaciones de trabajo</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl139" type="radio" name="186" value="ctl139" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl140" type="radio" name="186" value="ctl140" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl141" type="radio" name="186" value="ctl141" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl142" type="radio" name="186" value="ctl142" /></span></td></tr><tr><td width=75%>36 Recibo ayuda de mis compañeros de trabajo cuando lo solicito</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl143" type="radio" name="47" value="ctl143" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl144" type="radio" name="47" value="ctl144" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl145" type="radio" name="47" value="ctl145" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl146" type="radio" name="47" value="ctl146" /></span></td></tr><tr><td width=75%>37 Tengo la oportunidad de hacer sugerencias para mejorar el trabajo de mi departamento</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl147" type="radio" name="48" value="ctl147" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl148" type="radio" name="48" value="ctl148" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl149" type="radio" name="48" value="ctl149" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl150" type="radio" name="48" value="ctl150" /></span></td></tr><tr><td width=75%>38 En la Empresa se realizan eventos deportivos y tengo la oportunidad de participar</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl151" type="radio" name="188" value="ctl151" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl152" type="radio" name="188" value="ctl152" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl153" type="radio" name="188" value="ctl153" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl154" type="radio" name="188" value="ctl154" /></span></td></tr><tr><td width=75%>39 ¿En la empresa se realizan eventos sociales y de integracion?</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl155" type="radio" name="202" value="ctl155" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl156" type="radio" name="202" value="ctl156" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl157" type="radio" name="202" value="ctl157" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl158" type="radio" name="202" value="ctl158" /></span></td></tr><tr><td width=75%>40 Ya recibí el curso de inducción</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl159" type="radio" name="49" value="ctl159" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl160" type="radio" name="49" value="ctl160" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl161" type="radio" name="49" value="ctl161" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl162" type="radio" name="49" value="ctl162" /></span></td></tr><tr><td width=75%>41 La Empresa se ocupa por preparar bien a sus Asociados</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl163" type="radio" name="191" value="ctl163" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl164" type="radio" name="191" value="ctl164" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl165" type="radio" name="191" value="ctl165" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl166" type="radio" name="191" value="ctl166" /></span></td></tr><tr><td width=75%>42 Conozco bien como se hace mi trabajo</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl167" type="radio" name="52" value="ctl167" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl168" type="radio" name="52" value="ctl168" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl169" type="radio" name="52" value="ctl169" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl170" type="radio" name="52" value="ctl170" /></span></td></tr><tr><td width=75%>43 La empresa me apoya para preparame con cursos cuando lo solicito</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl171" type="radio" name="203" value="ctl171" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl172" type="radio" name="203" value="ctl172" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl173" type="radio" name="203" value="ctl173" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl174" type="radio" name="203" value="ctl174" /></span></td></tr><tr><td width=75%>44 Tengo la oportunidad de capacitarme si asi lo requiero</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl175" type="radio" name="204" value="ctl175" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl176" type="radio" name="204" value="ctl176" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl177" type="radio" name="204" value="ctl177" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl178" type="radio" name="204" value="ctl178" /></span></td></tr><tr><td width=75%>45 He recibido entrenamiento en aspectos de Seguridad</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl179" type="radio" name="55" value="ctl179" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl180" type="radio" name="55" value="ctl180" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl181" type="radio" name="55" value="ctl181" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl182" type="radio" name="55" value="ctl182" /></span></td></tr><tr><td width=75%>46 Se qué hacer en caso de que se active la ALARMA GENERAL en el edificio</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl183" type="radio" name="193" value="ctl183" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl184" type="radio" name="193" value="ctl184" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl185" type="radio" name="193" value="ctl185" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl186" type="radio" name="193" value="ctl186" /></span></td></tr><tr><td width=75%>47 Conozco las rutas de Evacuación</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl187" type="radio" name="57" value="ctl187" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl188" type="radio" name="57" value="ctl188" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl189" type="radio" name="57" value="ctl189" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl190" type="radio" name="57" value="ctl190" /></span></td></tr><tr><td width=75%>48 Las condiciones de seguridad en mi área de trabajo son adecuadas</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl191" type="radio" name="84" value="ctl191" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl192" type="radio" name="84" value="ctl192" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl193" type="radio" name="84" value="ctl193" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl194" type="radio" name="84" value="ctl194" /></span></td></tr><tr><td width=75%>49 He recibido capacitación o entrenamiento para saber qué hacer en caso de incendio</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl195" type="radio" name="85" value="ctl195" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl196" type="radio" name="85" value="ctl196" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl197" type="radio" name="85" value="ctl197" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl198" type="radio" name="85" value="ctl198" /></span></td></tr><tr><td width=75%>50 El comedor está en buen estado</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl199" type="radio" name="60" value="ctl199" /></span></td><td align=center valign=topwidth=6.25%><span title="Casi Nunca"><input id="ctl200" type="radio" name="60" value="ctl200" /></span></td><td align=center valign=topwidth=6.25%><span title="Frec."><input id="ctl201" type="radio" name="60" value="ctl201" /></span></td><td align=center valign=topwidth=6.25%><span title="Si"><input id="ctl202" type="radio" name="60" value="ctl202" /></span></td></tr><tr><td width=75%>53 Los baños están limpios y en buenas condiciones</td><td align=center valign=topwidth=6.25%><span title="No"><input id="ctl203" type="radio" name="63" value="ctl203" /></span></td>

	    <td>
		    <span title="Casi Nunca">
			    <input id="ctl204" type="radio" name="63" value="ctl204" />
		    </span>
	    </td>
	    <td>
		    <span title="Frec.">
			    <input id="ctl205" type="radio" name="63" value="ctl205" />
		    </span>
	    </td>
	    <td>
		    <span title="Si">
			    <input id="ctl206" type="radio" name="63" value="ctl206" />
		    </span>
	    </td>
	</tr>
	<tr>
		<td width=75%>54 Todas las áreas de la Empresa están limpias</td>
		<td align=center valign=topwidth=6.25%>
			<span title="No">
				<input id="ctl207" type="radio" name="194" value="ctl207" />
			</span>
		</td>
		<td align=center valign=topwidth=6.25%>
			<span title="Casi Nunca">
				<input id="ctl208" type="radio" name="194" value="ctl208" />
			</span>
		</td>
		<td align=center valign=topwidth=6.25%>
			<span title="Frec.">
				<input id="ctl209" type="radio" name="194" value="ctl209" />
			</span>
		</td>
		<td align=center valign=topwidth=6.25%>
			<span title="Si">
				<input id="ctl210" type="radio" name="194" value="ctl210" />
			</span>
		</td>
	</tr>
	<tr>
		<td width=75%>55 La Empresa se preocupa para que sus Asociados tengan buenos sueldos</td>
		<td align=center valign=topwidth=6.25%>
			<span title="No">
				<input id="ctl211" type="radio" name="196" value="ctl211" />
			</span>
		</td>
		<td align=center valign=topwidth=6.25%>
			<span title="Casi Nunca">
				<input id="ctl212" type="radio" name="196" value="ctl212" />
			</span>	
		</td>
		<td align=center valign=topwidth=6.25%>
			<span title="Frec.">
				<input id="ctl213" type="radio" name="196" value="ctl213" />
			</span>
		</td>
		<td align=center valign=topwidth=6.25%>
			<span title="Si">
				<input id="ctl214" type="radio" name="196" value="ctl214" />
			</span>
		</td>
	</tr>
	<tr>
		<td width=75%>56 Las prestaciones (aguinaldo, vales, etc.) que otorga la Empresa son buenas si se compara con las que dan en otras empresas.</td>
		<td align=center valign=topwidth=6.25%>
			<span title="No">
				<input id="ctl215" type="radio" name="195" value="ctl215" />
			</span>
		</td>
		<td align=center valign=topwidth=6.25%>
			<span title="Casi Nunca">
				<input id="ctl216" type="radio" name="195" value="ctl216" />
			</span>
		</td>
		<td align=center valign=topwidth=6.25%>
			<span title="Frec.">
				<input id="ctl217" type="radio" name="195" value="ctl217" />
			</span>
		</td>
		<td align=center valign=topwidth=6.25%>
			<span title="Si">
				<input id="ctl218" type="radio" name="195" value="ctl218" />
			</span>
		</td>
	</tr>
	<tr>
		<td width=75%>57 El sueldo que recibo es adecuado por el trabajo que hago</td>
		<td align=center valign=topwidth=6.25%>
			<span title="No">
				<input id="ctl219" type="radio" name="69" value="ctl219" />
			</span>
		</td>
		<td align=center valign=topwidth=6.25%>
			<span title="Casi Nunca">
				<input id="ctl220" type="radio" name="69" value="ctl220" />
			</span>
		</td>
		<td align=center valign=topwidth=6.25%>
			<span title="Frec.">
				<input id="ctl221" type="radio" name="69" value="ctl221" />
			</span>
		</td>
		<td align=center valign=topwidth=6.25%>
			<span title="Si">
				<input id="ctl222" type="radio" name="69" value="ctl222" />
			</span>
		</td>
	</tr>
	<tr>
		<td width=75%>58 El sueldo que recibo es el que se comprometió a pagarme el Hotel</td>
		<td align=center valign=topwidth=6.25%>
			<span title="No">
				<input id="ctl223" type="radio" name="114" value="ctl223" />
			</span>
		</td>
		<td align=center valign=topwidth=6.25%>
			<span title="Casi Nunca">
				<input id="ctl224" type="radio" name="114" value="ctl224" />
			</span>
		</td>
		<td align=center valign=topwidth=6.25%>
			<span title="Frec.">
				<input id="ctl225" type="radio" name="114" value="ctl225" />
			</span>
		</td>
		<td align=center valign=topwidth=6.25%>
			<span title="Si">
				<input id="ctl226" type="radio" name="114" value="ctl226" />
			</span>
		</td>
	</tr>
	<tr>
		<td width=75%>59 Me encuentro satisfecho de trabajar en este Hotel</td>
		<td align=center valign=topwidth=6.25%>
			<span title="No">
				<input id="ctl227" type="radio" name="198" value="ctl227" />
			</span>
		</td>
		<td align=center valign=topwidth=6.25%>
			<span title="Casi Nunca">
				<input id="ctl228" type="radio" name="198" value="ctl228" />
			</span>
		</td>
		<td align=center valign=topwidth=6.25%>
			<span title="Frec.">
				<input id="ctl229" type="radio" name="198" value="ctl229" />
			</span>
		</td>
		<td align=center valign=topwidth=6.25%>
			<span title="Si">
				<input id="ctl230" type="radio" name="198" value="ctl230" />
			</span>
		</td>
	</tr>
</table>

</body>
</html>
