<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ClimaLab.aspx.vb" Inherits="ClimaLab" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title>.: Encuesta Clima Laboral :.</title>
    
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
    /*    table#Table1 {
            width: 100%; 
            background-color: #f1f1c1;
        }*/
       
    </style>
    
<script language="javascript">	
/* 15 Septiembre del 2017 */
function redirect() {
    alert('Datos Guardados Con Éxito');
    document.location.href = "ClimaLab.aspx";
}
/**/

function ConvierteArreglo(texto,delimitador) {
	tempArray=new Array(1);
	var Count=0;
	var tempString=new String(texto);
	while (tempString.indexOf(delimitador)>0) {
		tempArray[Count]=tempString.substr(0,tempString.indexOf(delimitador));
		tempString=tempString.substr(tempString.indexOf(delimitador)+1,tempString.length-tempString.indexOf(delimitador)+1);
		Count=Count+1
	}
	tempArray[Count]=tempString;
	return tempArray;
}

function disableButton(buttonID) {
	document.getElementById(buttonID).disabled=true;
}

function test(){
    alert('LA ENCUESTA FUE GUARDADA CON ÉXITO');
}

function DisableButton() {
	
	var obj = document.getElementById("<%=cboHotel.ClientID%>");
	if (obj.options[obj.selectedIndex].value == 'AAAAAAA'){
		alert('Seleccione el hotel');
		obj.focus();
		return false;
	}
	
	var obj2 = document.getElementById("<%=cboSexo.ClientID%>");
	if (obj2.options[obj2.selectedIndex].value == '0'){
		alert('Selecciona un jefe');
		obj2.focus();
		return false;
	}
	
	obj = document.getElementById("<%=cboPeriodo.ClientID%>");
	if (obj.options[obj.selectedIndex].value == 0){
		alert('Seleccione el periodo');
		obj.focus();
		return false;
	}

	var svalue = txtvalida.value;
	
	//alert('svalue:'+svalue);
	
	var j = 0
	var arObj = ConvierteArreglo(svalue,",");
	
	/*alert('arObj:'+arObj);
	alert('arObj.length:'+arObj.length);*/
	
	var longitud = arObj.length	
	var k = 0
	for(var i = 0; i < arObj.length ; i++){
		k++;
		var radio = document.getElementById(arObj[i]);
		
		if (i > 0){

			var radioc = document.getElementById(arObj[i-1]);
			
			if (radio.name == radioc.name){
				if (radio.checked == false){
						j++;}
			}
			else {
				if (j == k-1){alert("Seleccione al menos una respuesta para la pregunta"); return false;}
				if (radio.checked == false) 
				j = 1;
				else 
				j=0;
				
				k = 1;
			} 			 
		}
		else{
			if (radio.checked == false){
				j++;}
		}
		
	}
	if ((i==arObj.length)&&(j==k)){
		{alert("Seleccione al menos una respuesta para la pregunta");return false;}
		}
		
 
		
	var r = confirm("Esta seguro de que desea guardar?")
	if (r==true){
		/*document.forms[0].submit();*/
		window.setTimeout("disableButton('" + 
		window.event.srcElement.id + "')", 0);
		return true
	}
	else{return false}
}


function SetContextKeyRecibe(){
    var cboHotel = $get("<%=cboHotel.ClientID%>");
    var idHotel = cboHotel.options[cboHotel.selectedIndex].value;
    $find('<%=AutoCompleteExtender_JefeProspecto.ClientID%>').set_contextKey($get("<%=cboHotel.ClientID%>").options[$get("<%=cboHotel.ClientID%>").selectedIndex].value);
    //alert('cboHotel:'+cboHotel.value);
}

function SetContextKeyRecibe_2(){
    var cboHotel = $get("<%=cboHotel.ClientID%>");
    var idHotel = cboHotel.options[cboHotel.selectedIndex].value;
    $find('<%=AutoCompleteExtender_JefeProspecto_2.ClientID%>').set_contextKey($get("<%=cboHotel.ClientID%>").options[$get("<%=cboHotel.ClientID%>").selectedIndex].value);
    //alert('cboHotel:'+cboHotel.value);
}

function SetContextKeyRecibe_3(){
    var cboHotel = $get("<%=cboHotel.ClientID%>");
    var idHotel = cboHotel.options[cboHotel.selectedIndex].value;
    $find('<%=AutoCompleteExtender_JefeProspecto_3.ClientID%>').set_contextKey($get("<%=cboHotel.ClientID%>").options[$get("<%=cboHotel.ClientID%>").selectedIndex].value);
    //alert('cboHotel:'+cboHotel.value);
}

function SetContextKeyRecibeEjemploSeguirI(){
    var cboHotel = $get("<%=cboHotel.ClientID%>");
    var idHotel = cboHotel.options[cboHotel.selectedIndex].value;
    $find('<%=AutoCompleteExtender_EjemploSeguir.ClientID%>').set_contextKey($get("<%=cboHotel.ClientID%>").options[$get("<%=cboHotel.ClientID%>").selectedIndex].value);
    //alert('cboHotel:'+cboHotel.value);
}

function SetContextKeyRecibeEjemploSeguirII(){
    var cboHotel = $get("<%=cboHotel.ClientID%>");
    var idHotel = cboHotel.options[cboHotel.selectedIndex].value;
    $find('<%=AutoCompleteExtender_EjemploSeguir_2.ClientID%>').set_contextKey($get("<%=cboHotel.ClientID%>").options[$get("<%=cboHotel.ClientID%>").selectedIndex].value);
    //alert('cboHotel:'+cboHotel.value);
}

function SetContextKeyRecibeEjemploSeguirIII(){
    var cboHotel = $get("<%=cboHotel.ClientID%>");
    var idHotel = cboHotel.options[cboHotel.selectedIndex].value;
    $find('<%=AutoCompleteExtender_EjemploSeguir_3.ClientID%>').set_contextKey($get("<%=cboHotel.ClientID%>").options[$get("<%=cboHotel.ClientID%>").selectedIndex].value);
    //alert('cboHotel:'+cboHotel.value);
}

function SetContextKeyorganizaReportesI(){
    var cboHotel = $get("<%=cboHotel.ClientID%>");
    var idHotel = cboHotel.options[cboHotel.selectedIndex].value;
    $find('<%=AutoCompleteExtender_OrganizaDeportes.ClientID%>').set_contextKey($get("<%=cboHotel.ClientID%>").options[$get("<%=cboHotel.ClientID%>").selectedIndex].value);
    //alert('cboHotel:'+cboHotel.value);
}

function SetContextKeyorganizaReportesII(){
    var cboHotel = $get("<%=cboHotel.ClientID%>");
    var idHotel = cboHotel.options[cboHotel.selectedIndex].value;
    $find('<%=AutoCompleteExtender_OrganizaDeportes_2.ClientID%>').set_contextKey($get("<%=cboHotel.ClientID%>").options[$get("<%=cboHotel.ClientID%>").selectedIndex].value);
    //alert('cboHotel:'+cboHotel.value);
}

function SetContextKeyorganizaReportesIII(){
    var cboHotel = $get("<%=cboHotel.ClientID%>");
    var idHotel = cboHotel.options[cboHotel.selectedIndex].value;
    $find('<%=AutoCompleteExtender_OrganizaDeportes_3.ClientID%>').set_contextKey($get("<%=cboHotel.ClientID%>").options[$get("<%=cboHotel.ClientID%>").selectedIndex].value);
    //alert('cboHotel:'+cboHotel.value);
}

</script>    
    
    
</head>
<body>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="Scripts/ScrollableTablePlugin_1.0_min.js" type="text/ecmascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#Table1').Scrollable({
                ScrollHeight: 500
            });
        });
    </script>

    <form id="form1" runat="server">
<br />  
<br />  
<!--    <div>-->
<TABLE id="Table2" cellSpacing="2" cellPadding="1" width="600" align="center" border="0">
	<TR>
		<TD style="HEIGHT: 11px">Hotel:</TD>
		<TD style="HEIGHT: 11px"><asp:dropdownlist id="cboHotel" runat="server" Width="186px" Height="24px" AutoPostBack="True"></asp:dropdownlist></TD>	
	</TR>
	<TR>
	    <TD style="HEIGHT: 11px">Departamento:</TD>
		<TD style="HEIGHT: 11px"><asp:dropdownlist id="cboDepto" runat="server" Width="400px" Height="24px" AutoPostBack="True"></asp:dropdownlist></TD>
	</TR>
	<TR>
	<TD>Jefe:</TD>
		<TD><asp:dropdownlist id="cboSexo" runat="server" Width="268px" Height="24px" AutoPostBack="True"></asp:dropdownlist></TD>
	</TR>
	<TR style="display:none">
		<TD style="HEIGHT: 11px">Cuestionario:</TD>
		<TD style="HEIGHT: 11px"><asp:dropdownlist id="cboCuestionario" runat="server" Width="160px" Height="24px" AutoPostBack="True"></asp:dropdownlist></TD>
		<TD>Año:</TD>
		<TD><asp:dropdownlist id="cboAnio" runat="server" Width="160px" Height="24px"></asp:dropdownlist></TD>
	</TR>
	<tr style="display:none">
		<TD style="HEIGHT: 11px">Periodo:</TD>
		<TD style="HEIGHT: 11px"><asp:dropdownlist id="cboPeriodo" runat="server" Width="160px" Height="24px" Enabled="False"></asp:dropdownlist></TD>
		<td>Folio:</td>
		<td>
			<asp:TextBox id="txtFolio" runat="server"></asp:TextBox></td>
	</tr>
</TABLE>
<br />
<br />
<TABLE id="tblMain" cellSpacing="0" cellPadding="0" width="680" align="center" border="0">
	<TR>
		<TD align="center"><asp:placeholder id="plcTitulo" runat="server"></asp:placeholder><IMG height="3" alt="image" src="picts\paragraph-line.jpg" width="100%" vspace="7" border="0">
			<br>
		</TD>
	</TR>
	<TR>
		<TD><asp:placeholder id="plcInstruccion" runat="server"></asp:placeholder></TD>
	</TR>
	<TR>
		<TD><asp:placeholder id="plcCuerpo" runat="server"></asp:placeholder></TD>
	</TR>
	<TR>
	    <td>
	        <BR />
	    </td>
	</TR>
	<TR>
		<TD>
		    <div runat="server" id="Jefe_Prospecto">
		    <!--->
            <table width="100%" border="0">
                <tr>
                    <td style="width:50%">
                        <asp:Label ID="LblJefeProspecto" runat="server" Text="¿Quien te gustaria que fuera tu jefe Inmediato?"></asp:Label></td>
                    <td style="width:50%">
                        <asp:TextBox ID="txtProspectoJefe" 
                                    AutoPostBack="false"
                                    runat="server" 
                                    Width="270px" 
                                    OnTextChanged="setIdAgrupacion" >
                        </asp:TextBox>
                        <asp:HiddenField ID="HddnIdEmpleado" runat="server" Value="0" />                        
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender_JefeProspecto" 
                                    runat="server"
                                    DelimiterCharacters="" 
                                    Enabled="True" 
                                    ServiceMethod="GetNombreProspectoJefeList_ProspectoJefe" 
                                    ServicePath="" 
                                    TargetControlID="txtProspectoJefe" 
                                    UseContextKey="True" 
                                    MinimumPrefixLength="2" 
                                    CompletionInterval="10" 
                                    EnableCaching="true" 
                                    CompletionSetCount="20" >
                        </cc1:AutoCompleteExtender>                    
                    </td>
                </tr>
            </table>
            </div>
		</TD>	
	</TR>
	<TR>
		<TD>
		    <div runat="server" id="Jefe_Prospecto_2">
		    <!--BORDER 1-->
            <table width="100%" border="0">
                <tr>
                    <td style="width:50%">
                        
                    <td style="width:50%">
                        <asp:TextBox ID="txtProspectoJefe_2" 
                                    AutoPostBack="false"
                                    runat="server" 
                                    Width="270px" 
                                    OnTextChanged="setIdAgrupacion_2" >
                        </asp:TextBox>
                        <asp:HiddenField ID="HddnIdEmpleado_2" runat="server" Value="0" />                        
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender_JefeProspecto_2" 
                                    runat="server"
                                    DelimiterCharacters="" 
                                    Enabled="True" 
                                    ServiceMethod="GetNombreProspectoJefeList_ProspectoJefe_2" 
                                    ServicePath="" 
                                    TargetControlID="txtProspectoJefe_2" 
                                    UseContextKey="True"
                                    MinimumPrefixLength="2"
                                    CompletionInterval="10" 
                                    EnableCaching="true" 
                                    CompletionSetCount="20" >
                        </cc1:AutoCompleteExtender>                    
                    </td>
                </tr>
            </table>
            </div>
		</TD>	
	</TR>		
	<TR>
		<TD>
		    <div runat="server" id="Jefe_Prospecto_3">
		    <!-- BORDER 1 -->
            <table width="100%" border="0">
                <tr>
                    <td style="width:50%">
                        
                    <td style="width:50%">
                        <asp:TextBox ID="txtProspectoJefe_3" 
                                    AutoPostBack="false"
                                    runat="server" 
                                    Width="270px" 
                                    OnTextChanged="setIdAgrupacion_3" >
                        </asp:TextBox>
                        <asp:HiddenField ID="HddnIdEmpleado_3" runat="server" Value="0" />
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender_JefeProspecto_3" 
                                    runat="server"
                                    DelimiterCharacters="" 
                                    Enabled="True" 
                                    ServiceMethod="GetNombreProspectoJefeList_ProspectoJefe_3" 
                                    ServicePath="" 
                                    TargetControlID="txtProspectoJefe_3" 
                                    UseContextKey="True"
                                    MinimumPrefixLength="2"
                                    CompletionInterval="10" 
                                    EnableCaching="true" 
                                    CompletionSetCount="20" >
                        </cc1:AutoCompleteExtender>                    
                    </td>
                </tr>
            </table>
            </div>
		</TD>	
	</TR>	
	<tr>
		<TD>
		    <div runat="server" id="ejemplo_seguir">
		    <!-- BORDER 1 -->
            <table width="100%" border="0">
                <tr>
                    <td style="width:50%">
                        <asp:Label ID="LablEjemploSeguir" runat="server" Text="¿Quién crees que es un ejemplo a seguir en aspectos de trabajo y compañerismo?"></asp:Label>
                    </td>
                    <td style="width:50%">
                        <asp:TextBox ID="txtEjemploSeguir" 
                                    AutoPostBack="false"
                                    runat="server" 
                                    Width="270px" 
                                    OnTextChanged="setIdEmpleadoEjemploSeguirI" >
                        </asp:TextBox>
                        <asp:HiddenField ID="HddIdEmpleadoEjemploSeguirI" runat="server" Value="0" />                        
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender_EjemploSeguir" 
                                    runat="server"
                                    DelimiterCharacters="" 
                                    Enabled="True" 
                                    ServiceMethod="GetNombreProspectoJefeList_EjemploASeguir" 
                                    ServicePath="" 
                                    TargetControlID="txtEjemploSeguir" 
                                    UseContextKey="True" 
                                    MinimumPrefixLength="2" 
                                    CompletionInterval="10" 
                                    EnableCaching="true" 
                                    CompletionSetCount="20" >
                        </cc1:AutoCompleteExtender>                    
                    </td>
                </tr>
            </table>
            </div>
		</TD>		
	</tr>
	<TR>
		<TD>
		    <div runat="server" id="ejemplo_seguir_2">
		    <!-- BORDER 1 -->
            <table width="100%" border="0">
                <tr>
                    <td style="width:50%">
                        
                    <td style="width:50%">
                        <asp:TextBox ID="txtEjemploSeguir_2" 
                                    AutoPostBack="false"
                                    runat="server" 
                                    Width="270px" 
                                    OnTextChanged="setIdEmpleadoEjemploSeguirII" >
                        </asp:TextBox>
                        <asp:HiddenField ID="HddIdEmpleadoEjemploSeguirII" runat="server" Value="0" />                        
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender_EjemploSeguir_2" 
                                    runat="server"
                                    DelimiterCharacters="" 
                                    Enabled="True" 
                                    ServiceMethod="GetNombreProspectoJefeList_EjemploASeguir_2" 
                                    ServicePath="" 
                                    TargetControlID="txtEjemploSeguir_2" 
                                    UseContextKey="True" 
                                    MinimumPrefixLength="2" 
                                    CompletionInterval="10" 
                                    EnableCaching="true" 
                                    CompletionSetCount="20" >
                        </cc1:AutoCompleteExtender>                    
                    </td>
                </tr>
            </table>
            </div>
		</TD>	
	</TR>	
	<TR>
		<TD>
		    <div runat="server" id="ejemplo_seguir_3">
		    <!-- BORDER 1 -->
            <table width="100%" border="0">
                <tr>
                    <td style="width:50%">
                        
                    <td style="width:50%">
                        <asp:TextBox ID="txtEjemploSeguir_3" 
                                    AutoPostBack="false"
                                    runat="server" 
                                    Width="270px" 
                                    OnTextChanged="setIdEmpleadoEjemploSeguirIII" >
                        </asp:TextBox>
                        <asp:HiddenField ID="HddIdEmpleadoEjemploSeguirIII" runat="server" Value="0" />                        
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender_EjemploSeguir_3" 
                                    runat="server"
                                    DelimiterCharacters="" 
                                    Enabled="True" 
                                    ServiceMethod="GetNombreProspectoJefeList_EjemploASeguir_3" 
                                    ServicePath="" 
                                    TargetControlID="txtEjemploSeguir_3" 
                                    UseContextKey="True" 
                                    MinimumPrefixLength="2" 
                                    CompletionInterval="10" 
                                    EnableCaching="true" 
                                    CompletionSetCount="20" >
                        </cc1:AutoCompleteExtender>                    
                    </td>
                </tr>
            </table>
            </div>
		</TD>	
	</TR>
	<tr>
		<TD>
		    <div runat="server" id="organizaReportes">
		    <!-- BORDER 1 -->
            <table width="100%" border="0">
                <tr>
                    <td style="width:50%">
                        <asp:Label ID="LblOrganizaDeportes" runat="server" Text="¿A quiénes consideras más interesados en organizar deportes o actividades entre el personal?"></asp:Label>
                    </td>
                    <td style="width:50%">
                        <asp:TextBox ID="txtOrganizaDeportes" 
                                    AutoPostBack="false"
                                    runat="server" 
                                    Width="270px" 
                                    OnTextChanged="setIdEmpleadoorganizaReportesI" >
                        </asp:TextBox>
                        <asp:HiddenField ID="HddnEmpleadoOrganizaReportesI" runat="server" Value="0" />                        
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender_OrganizaDeportes"
                                    runat="server"
                                    DelimiterCharacters="" 
                                    Enabled="True" 
                                    ServiceMethod="GetNombreProspectoJefeList_OrganizaDeportes"
                                    ServicePath="" 
                                    TargetControlID="txtOrganizaDeportes" 
                                    UseContextKey="True" 
                                    MinimumPrefixLength="2" 
                                    CompletionInterval="10" 
                                    EnableCaching="true" 
                                    CompletionSetCount="20" >
                        </cc1:AutoCompleteExtender>                    
                    </td>
                </tr>
            </table>
            </div>
		</TD>		
	</tr>
	<TR>
		<TD>
		    <div runat="server" id="organizaReportes_2">
		    <!-- BORDER 1 -->
            <table width="100%" border="0">
                <tr>
                    <td style="width:50%">
                        
                    <td style="width:50%">
                        <asp:TextBox ID="txtOrganizaDeportes_2" 
                                    AutoPostBack="false"
                                    runat="server" 
                                    Width="270px" 
                                    OnTextChanged="setIdEmpleadoorganizaReportesII" >
                        </asp:TextBox>
                        <asp:HiddenField ID="HddnEmpleadoOrganizaReportesII" runat="server" Value="0" />                        
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender_OrganizaDeportes_2"
                                    runat="server"
                                    DelimiterCharacters="" 
                                    Enabled="True" 
                                    ServiceMethod="GetNombreProspectoJefeList_OrganizaDeportes_2"
                                    ServicePath="" 
                                    TargetControlID="txtOrganizaDeportes_2" 
                                    UseContextKey="True" 
                                    MinimumPrefixLength="2" 
                                    CompletionInterval="10" 
                                    EnableCaching="true" 
                                    CompletionSetCount="20" >
                        </cc1:AutoCompleteExtender>                      
                    </td>
                </tr>
            </table>
            </div>
		</TD>	
	</TR>		
	<TR>
		<TD>
		    <div runat="server" id="organizaReportes_3">
		    <!-- BORDER 1 -->
            <table width="100%" border="0">
                <tr>
                    <td style="width:50%">
                        
                    <td style="width:50%">
                        <asp:TextBox ID="txtOrganizaDeportes_3" 
                                    AutoPostBack="false"
                                    runat="server" 
                                    Width="270px" 
                                    OnTextChanged="setIdEmpleadoorganizaReportesIII" >
                        </asp:TextBox>
                        <asp:HiddenField ID="HddnEmpleadoOrganizaReportesIII" runat="server" Value="0" />                        
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender_OrganizaDeportes_3"
                                    runat="server"
                                    DelimiterCharacters="" 
                                    Enabled="True" 
                                    ServiceMethod="GetNombreProspectoJefeList_OrganizaDeportes_3"
                                    ServicePath="" 
                                    TargetControlID="txtOrganizaDeportes_3" 
                                    UseContextKey="True" 
                                    MinimumPrefixLength="2" 
                                    CompletionInterval="10" 
                                    EnableCaching="true" 
                                    CompletionSetCount="20" >
                        </cc1:AutoCompleteExtender>
                    </td>
                </tr>
            </table>
            </div>
		</TD>
	</TR>
	<TR>
		<TD class="phonetitle" align="center"><br>
			<br>
			Gracias por su tiempo.</TD>
	</TR>
	<TR>
		<TD align="center" style="height: 45px">
			<table>
				<tr>
					<td width="33%"><asp:button id="btnLimpiar" runat="server" Text=" Limpiar " CssClass="surveybutton" CausesValidation="False" Enabled="False" Visible="False"></asp:button></td>				
					<td width="33%"><asp:button id="btnEnviar" runat="server" Text="  Enviar  " CssClass="surveybutton"></asp:button></td>
					<td width="33%"><asp:button id="btnCancelar" runat="server" Text=" Cancelar " CssClass="surveybutton" CausesValidation="False" Enabled="False" Visible="False"></asp:button></td>
				</tr>
			</table>
		</TD>
	</TR>
</TABLE>
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True" EnableScriptLocalization="True">
</asp:ScriptManager>
<asp:textbox id="txtNumEval" runat="server" Visible="False">
</asp:textbox>
<INPUT id="txtValida" style="Z-INDEX: 109; LEFT: 200px; WIDTH: 101px; POSITION: absolute; TOP: 392px; HEIGHT: 19px" type="hidden" size="11" name="txtValida">
    
<!--    </div>-->
    </form>
</body>
</html>
