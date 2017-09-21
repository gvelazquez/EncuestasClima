
Imports System.Threading

Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Imports System.Collections.Generic

Partial Class ClimaLab
    Inherits System.Web.UI.Page
    'Inherits ControlBase

    Public enviar As Integer


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    'Protected WithEvents RequiredFieldValidatorHotel As System.Web.UI.WebControls.RequiredFieldValidator
    'Protected WithEvents RequiredFieldValidatorPeriodo As System.Web.UI.WebControls.RequiredFieldValidator
    'Protected WithEvents RequiredFieldValidatorSexo As System.Web.UI.WebControls.RequiredFieldValidator
    'Protected WithEvents cboCuestionario As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents cboHotel As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents cboAnio As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents cboPeriodo As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents cboSexo As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents plcTitulo As System.Web.UI.WebControls.PlaceHolder
    'Protected WithEvents plcInstruccion As System.Web.UI.WebControls.PlaceHolder
    'Protected WithEvents plcCuerpo As System.Web.UI.WebControls.PlaceHolder
    'Protected WithEvents btnEnviar As System.Web.UI.WebControls.Button
    'Protected WithEvents btnLimpiar As System.Web.UI.WebControls.Button
    'Protected WithEvents txtNumEval As System.Web.UI.WebControls.TextBox
    'Protected WithEvents btnCancelar As System.Web.UI.WebControls.Button
    'Protected WithEvents txtFolio As System.Web.UI.WebControls.TextBox

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Public Shared diccProspectoJefe As Dictionary(Of String, Integer)

    Public Shared diccJefeProspecto As Dictionary(Of String, Integer)
    Public Shared diccJefeProspecto_2 As Dictionary(Of String, Integer)
    Public Shared diccJefeProspecto_3 As Dictionary(Of String, Integer)

    Public Shared diccEjemploASeguir As Dictionary(Of String, Integer)
    Public Shared diccEjemploASeguir_2 As Dictionary(Of String, Integer)
    Public Shared diccEjemploASeguir_3 As Dictionary(Of String, Integer)

    Public Shared diccOrganizaDeportes As Dictionary(Of String, Integer)
    Public Shared diccOrganizaDeportes_2 As Dictionary(Of String, Integer)
    Public Shared diccOrganizaDeportes_3 As Dictionary(Of String, Integer)

    Public Shared idhotelCmboHotel As String

    'Public Shared actualizaListaJefe As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        btnEnviar.Attributes.Add("onclick", "return DisableButton();")
        'btnEnviar.Attributes.Add("onclick", "return test();")

        '-- Si La Pagina no hace Post Back --
        If Not Page.IsPostBack Then

            Me.Jefe_Prospecto.Visible = False
            Me.Jefe_Prospecto_2.Visible = False
            Me.Jefe_Prospecto_3.Visible = False
            Me.ejemplo_seguir.Visible = False
            Me.ejemplo_seguir_2.Visible = False
            Me.ejemplo_seguir_3.Visible = False
            Me.organizaReportes.Visible = False
            Me.organizaReportes_2.Visible = False
            Me.organizaReportes_3.Visible = False

            If Request.QueryString("Saved") = "1" Then
                'ClientScript.RegisterClientScriptBlock(Me.GetType, "alert", "alert('Database updated.')", True)
                ClientScript.RegisterStartupScript(Me.Page.GetType, "Script", "test();", True)
            End If

            Dim dtHoteles As DataTable
            Dim dataHoteles As New DataConn
            dataHoteles.SeccionConnStr = "CadenaConexion"
            dtHoteles = dataHoteles.fncSelHoteles
            If dtHoteles.Rows.Count > 0 Then
                cboHotel.DataSource = dtHoteles
                cboHotel.DataTextField = "Nombre"
                cboHotel.DataValueField = "IdHotel"
                cboHotel.DataBind()
            End If

            If idhotelCmboHotel <> "" Then
                cboHotel.SelectedValue = idhotelCmboHotel

                Dim dtHotel As DataTable
                Dim dataHotel As New DataConn
                dataHotel.SeccionConnStr = "CadenaConexion"
                dtHotel = dataHotel.fncSelJefes(idhotelCmboHotel)

                If dtHotel.Rows.Count Then
                    cboSexo.DataSource = dtHotel
                    cboSexo.DataTextField = "Nombre"
                    cboSexo.DataValueField = "IdUsuario"
                    cboSexo.DataBind()
                End If
            End If

            'Dim dtCuestionario As New DataTable
            'Dim dataCuestionario As New DataConn
            'dataCuestionario.SeccionConnStr = "CadenaConexion"
            'dtCuestionario = dataCuestionario.fncSelCuestionarios(Me.cboHotel.SelectedValue)
            'If dtCuestionario.Rows.Count > 0 Then
            '    cboCuestionario.DataSource = dtCuestionario
            '    cboCuestionario.DataTextField = "Titulo"
            '    cboCuestionario.DataValueField = "IdCuestionario"
            '    cboCuestionario.DataBind()
            'End If

            Dim dtAnio As DataTable
            Dim dataAnio As New DataConn
            dataAnio.SeccionConnStr = "CadenaConexion"
            dtAnio = dataAnio.fncAnioEncuesta
            If dtAnio.Rows.Count > 0 Then
                cboAnio.DataSource = dtAnio
                cboAnio.DataTextField = "anio"
                cboAnio.DataValueField = "idanio"
                cboAnio.DataBind()
            End If

            Dim dtPeriodo As DataTable
            Dim dataPeriodo As New DataConn
            dataPeriodo.SeccionConnStr = "CadenaConexion"
            dtPeriodo = dataPeriodo.fncPeriodoEncuesta
            If dtPeriodo.Rows.Count > 0 Then
                cboPeriodo.DataSource = dtPeriodo
                cboPeriodo.DataTextField = "Descripcion"
                cboPeriodo.DataValueField = "IdPeriodo"
                cboPeriodo.DataBind()
            End If

            '--- nuevo ---
            If Me.cboHotel.SelectedValue <> "AAAAAAA" Then
                Dim dtCuestionario As New DataTable
                Dim dataCuestionario As New DataConn
                dataCuestionario.SeccionConnStr = "CadenaConexion"
                dtCuestionario = dataCuestionario.fncSelCuestionarios(Me.cboHotel.SelectedValue)
                If dtCuestionario.Rows.Count > 0 Then
                    cboCuestionario.DataSource = dtCuestionario
                    cboCuestionario.DataTextField = "Titulo"
                    cboCuestionario.DataValueField = "IdCuestionario"
                    cboCuestionario.DataBind()
                End If
            End If

        Else 'SI LA PAGINA HACE POST BACK

            Dim shotel, str, valor As String

            shotel = cboHotel.SelectedValue

            'If idhotelCmboHotel <> shotel Then
            If shotel = "AAAAAAA" Then
                cboSexo.Items.Clear()
            Else
                'str = "Select Idhotel_Dataware from Hoteles where Idhotel = '" + shotel + "'"
                Dim selectedValue As String = Me.cboSexo.SelectedValue

                Dim dtHotel As DataTable
                Dim dataHotel As New DataConn
                dataHotel.SeccionConnStr = "CadenaConexion"
                dtHotel = dataHotel.fncSelJefes(shotel)

                If dtHotel.Rows.Count Then
                    cboSexo.DataSource = dtHotel
                    cboSexo.DataTextField = "Nombre"
                    cboSexo.DataValueField = "IdUsuario"
                    cboSexo.DataBind()
                End If

                If selectedValue <> "" Then
                    If Me.cboSexo.Items.Count > 0 Then
                        For Each item As Object In Me.cboSexo.Items
                            Dim itemValue As String = item.value.ToString
                            If itemValue = selectedValue Then
                                cboSexo.SelectedValue = selectedValue
                                Exit For
                            End If
                        Next
                    End If
                End If

                'nuevo
                Dim dtCuestionario As New DataTable
                Dim dataCuestionario As New DataConn
                dataCuestionario.SeccionConnStr = "CadenaConexion"
                dtCuestionario = dataCuestionario.fncSelCuestionarios(Me.cboHotel.SelectedValue)
                If dtCuestionario.Rows.Count > 0 Then
                    cboCuestionario.DataSource = dtCuestionario
                    cboCuestionario.DataTextField = "Titulo"
                    cboCuestionario.DataValueField = "IdCuestionario"
                    cboCuestionario.DataBind()
                End If
            End If
            'End If

        End If

        '--- Siempre que se carge pa pagina pregunta para obtener el Contenido de la evaluacion ---
        If Me.cboCuestionario.Items.Count > 0 Then

            Me.Jefe_Prospecto.Visible = True
            Me.Jefe_Prospecto_2.Visible = True
            Me.Jefe_Prospecto_3.Visible = True
            Me.ejemplo_seguir.Visible = True
            Me.ejemplo_seguir_2.Visible = True
            Me.ejemplo_seguir_3.Visible = True
            Me.organizaReportes.Visible = True
            Me.organizaReportes_2.Visible = True
            Me.organizaReportes_3.Visible = True

            If Request.QueryString("Eval") Is Nothing Then
                GeneraEvaluacion(cboCuestionario.SelectedValue)
            Else
                cboCuestionario.SelectedValue = Request.QueryString("Eval")
                GeneraEvaluacion(Request.QueryString("Eval"))
            End If
        End If

    End Sub

    Private Sub GeneraEvaluacion(ByVal IdEvaluacion As Integer)
        If ConstruyeTitulo(IdEvaluacion) Then
            If Not ConstruyeCuerpo(IdEvaluacion) Then
                'utilerias.creaMensaje(Me.Page, "Existe un error en la creación de la evaluación, por favor comuníquese " & _
                '  "al Departamento de Base de datos.\nError en la creación del cuerpo de la evaluación", "alertKey")
            End If
            'Response.Write("<script languaje='javascript'>alert('el cuerpo contiene " + Me.plcCuerpo.Controls.Count.ToString + " controles');</script>")
            'Response.Write("<script languaje='javascript'>alert('Los datos Ingresados ya existen');</script>")
        End If
    End Sub

    Private Function ConstruyeTitulo(ByVal IdEval As Integer) As Boolean
        Dim sTitulo, sIntruccion As String

        Dim dtEncabezado As DataTable
        Dim dataEncabezado As New DataConn

        dataEncabezado.SeccionConnStr = "CadenaConexion"
        dtEncabezado = dataEncabezado.fncTituloEncuesta(IdEval)
        If dtEncabezado.Rows.Count Then
            sTitulo = dtEncabezado.Rows(0).Item("Titulo")
            sIntruccion = dtEncabezado.Rows(0).Item("Instruccion")
            plcTitulo.Controls.Add(New LiteralControl("<p class=title>"))
            plcTitulo.Controls.Add(New LiteralControl(sTitulo))
            plcTitulo.Controls.Add(New LiteralControl("</p>"))

            plcInstruccion.Controls.Add(New LiteralControl("<p class=phonetitle>"))
            plcInstruccion.Controls.Add(New LiteralControl(sIntruccion))
            plcInstruccion.Controls.Add(New LiteralControl("</p>"))

            ConstruyeTitulo = True
        End If

    End Function

    Private Function ConstruyeCuerpo(ByVal IdEval As Integer) As Boolean
        Dim sTipo, sPregunta, sOpcion, sValida, sValida2 As String
        'Dim sConnString As String = ConfigurationSettings.AppSettings("ConnEvalClimaLab")
        'Dim sqlConn As New SqlClient.SqlConnection(sConnString)
        Dim iOpMax As Integer = 0
        Dim bOpMax As Boolean = False
        Dim bEncOpMult As Boolean = False

        sValida = ""

        'Dim oCmd As New SqlClient.SqlCommand
        'Dim oDr As SqlClient.SqlDataReader

        'oCmd.Connection = sqlConn
        'oCmd.CommandType = CommandType.StoredProcedure
        'oCmd.Parameters.Clear()
        'oCmd.CommandText = "SpSelConsultaPreguntas"
        'oCmd.Parameters.Add("@IdEvaluacion", SqlDbType.Int).Value = IdEval

        Dim dtCuerpo As DataTable
        Dim dataCuerpo As New DataConn

        dataCuerpo.SeccionConnStr = "CadenaConexion"
        'dtCuerpo = dataCuerpo.fncPreguntasEncuesta(IdEval)
        dtCuerpo = dataCuerpo.fncPreguntasEncuestaxHotel(Me.cboHotel.SelectedValue, IdEval)
        Dim oDr As DataTableReader = dtCuerpo.CreateDataReader()

        Try

            While oDr.Read

                If CType(oDr.Item("Tipo"), String).ToUpper.IndexOf("ABIERTA") > 0 Then

                    plcCuerpo.Controls.Add(New LiteralControl("<div class=just>"))
                    plcCuerpo.Controls.Add(New LiteralControl(CType(oDr.Item("Pregunta"), String)))
                    plcCuerpo.Controls.Add(New LiteralControl("<br>"))
                    Dim Box As New TextBox
                    Box.ID = CType(oDr.Item("IdPregunta"), String)
                    Box.TextMode = TextBoxMode.MultiLine
                    Box.Width = New Unit("100%")
                    Box.Rows = 3
                    Box.MaxLength = 2000
                    Box.Wrap = True

                    plcCuerpo.Controls.Add(Box)
                    plcCuerpo.Controls.Add(New LiteralControl("<br>"))
                    plcCuerpo.Controls.Add(New LiteralControl("<br>"))
                    plcCuerpo.Controls.Add(New LiteralControl("<br>"))
                    plcCuerpo.Controls.Add(New LiteralControl("<br>"))
                    plcCuerpo.Controls.Add(New LiteralControl("</div>"))

                ElseIf CType(oDr.Item("Tipo"), String).ToUpper.IndexOf("MULTIPLE") > 0 Then 'Opcion Multiple
                    'consulta el numero maximo de opciones para configurar la celdas.
                    If Not bOpMax Then


                        'Dim sqlConn2 As New SqlClient.SqlConnection(sConnString)
                        'Dim oCmd2 As New SqlClient.SqlCommand
                        'Dim oDr2 As SqlClient.SqlDataReader

                        'oCmd2.Connection = sqlConn2
                        'oCmd2.CommandType = CommandType.StoredProcedure
                        'oCmd2.CommandText = "SpSelTotalOpXPregunta"
                        'oCmd2.Parameters.Clear()
                        'oCmd2.Parameters.Add("@IdEvaluacion", SqlDbType.Int).Value = IdEval

                        'sqlConn2.Open()
                        'oDr2 = oCmd2.ExecuteReader()

                        Dim dtCuerpo2 As DataTable
                        Dim dataCuerpo2 As New DataConn
                        dataCuerpo2.SeccionConnStr = "CadenaConexion"
                        dtCuerpo2 = dataCuerpo2.fncTotalOpXPregunta(IdEval)
                        Dim oDr2 As DataTableReader = dtCuerpo2.CreateDataReader()

                        While oDr2.Read
                            If iOpMax < CType(oDr2.Item("TOTAL"), Integer) Then
                                iOpMax = CType(oDr2.Item("TOTAL"), Integer)
                            End If
                        End While
                        If Not oDr2 Is Nothing Then
                            oDr2.Close()
                            oDr2 = Nothing
                        End If
                        'sqlConn2.Close()
                        'sqlConn2.Dispose()
                        bOpMax = True
                    End If

                    'plcCuerpo.Controls.Add(New LiteralControl("<table class='scroll' width=100% border=1>"))'test
                    ''''''''''plcCuerpo.Controls.Add(New LiteralControl("<table width=100%>"))
                    'plcCuerpo.Controls.Add(New LiteralControl("<div class=just>"))
                    'plcCuerpo.Controls.Add(New LiteralControl("<thead>")) '' nuevo

                    'Construye encabezado de imagenes
                    If Not bEncOpMult Then
                        'plcCuerpo.Controls.Add(New LiteralControl("<table width=100%>"))'ok
                        'plcCuerpo.Controls.Add(New LiteralControl("<table class=""scroll"" width=100%>")) 'test
                        plcCuerpo.Controls.Add(New LiteralControl("<table  cellspacing=""0"" rules=""all"" border=""1"" id=""Table1"" style=""border-collapse: collapse;"">")) 'test
                        'plcCuerpo.Controls.Add(New LiteralControl("<thead>")) 'test
                        plcCuerpo.Controls.Add(New LiteralControl("<tr>"))
                        Select Case iOpMax
                            Case 4 '5
                                plcCuerpo.Controls.Add(New LiteralControl("<td width=600>")) 'width=75%
                                plcCuerpo.Controls.Add(New LiteralControl("</td>"))
                                plcCuerpo.Controls.Add(New LiteralControl("<td width=45 align=center>")) 'align=center width=6.25%
                                'plcCuerpo.Controls.Add(New LiteralControl("<IMG alt=No src=picts\Encuesta\Insatisfecho.ico border=0>"))
                                plcCuerpo.Controls.Add(New LiteralControl("<label>no</label>"))
                                plcCuerpo.Controls.Add(New LiteralControl("</td>"))
                                plcCuerpo.Controls.Add(New LiteralControl("<td width=45 align=center>")) ' align=center width=6.25%
                                'plcCuerpo.Controls.Add(New LiteralControl("<IMG alt=Casi Nunca src=picts\Encuesta\Algo_Insatisfecho.ico border=0>"))
                                plcCuerpo.Controls.Add(New LiteralControl("<label>casi nunca</label>"))
                                plcCuerpo.Controls.Add(New LiteralControl("</td>"))
                                plcCuerpo.Controls.Add(New LiteralControl("<td width=45 align=center>")) ' align=center width=6.25%
                                'plcCuerpo.Controls.Add(New LiteralControl("<IMG alt=Frec. src=picts\Encuesta\Algo_Satisfecho.ico border=0>"))
                                plcCuerpo.Controls.Add(New LiteralControl("<label>frecc</label>"))
                                plcCuerpo.Controls.Add(New LiteralControl("</td>"))
                                plcCuerpo.Controls.Add(New LiteralControl("<td width=45 align=center>")) ' align=center width=6.25%
                                'plcCuerpo.Controls.Add(New LiteralControl("<IMG alt=Si src=picts\Encuesta\satisfecho.ico border=0>"))
                                plcCuerpo.Controls.Add(New LiteralControl("<label>si</label>"))
                                plcCuerpo.Controls.Add(New LiteralControl("</td>"))
                                'plcCuerpo.Controls.Add(New LiteralControl("<td align=center>"))
                                'plcCuerpo.Controls.Add(New LiteralControl("<IMG alt=N/A src=picts\Encuesta\Neutral.ico border=0>"))
                                'plcCuerpo.Controls.Add(New LiteralControl("<label>n/a</label>"))
                                'plcCuerpo.Controls.Add(New LiteralControl("</td>"))
                            Case 5
                                plcCuerpo.Controls.Add(New LiteralControl("<td width=75%>"))
                                plcCuerpo.Controls.Add(New LiteralControl("</td>"))
                                plcCuerpo.Controls.Add(New LiteralControl("<td align=center>"))
                                'plcCuerpo.Controls.Add(New LiteralControl("<IMG alt=No src=picts\Encuesta\Insatisfecho.ico border=0>"))
                                plcCuerpo.Controls.Add(New LiteralControl("<label>no</label>"))
                                plcCuerpo.Controls.Add(New LiteralControl("</td>"))
                                plcCuerpo.Controls.Add(New LiteralControl("<td align=center>"))
                                'plcCuerpo.Controls.Add(New LiteralControl("<IMG alt=Casi Nunca src=picts\Encuesta\Algo_Insatisfecho.ico border=0>"))
                                plcCuerpo.Controls.Add(New LiteralControl("<label>casi nunca</label>"))
                                plcCuerpo.Controls.Add(New LiteralControl("</td>"))
                                plcCuerpo.Controls.Add(New LiteralControl("<td align=center>"))
                                'plcCuerpo.Controls.Add(New LiteralControl("<IMG alt=Frec. src=picts\Encuesta\Algo_Satisfecho.ico border=0>"))
                                plcCuerpo.Controls.Add(New LiteralControl("<label>frecc</label>"))
                                plcCuerpo.Controls.Add(New LiteralControl("</td>"))
                                plcCuerpo.Controls.Add(New LiteralControl("<td align=center>"))
                                'plcCuerpo.Controls.Add(New LiteralControl("<IMG alt=Si src=picts\Encuesta\satisfecho.ico border=0>"))
                                plcCuerpo.Controls.Add(New LiteralControl("<label>si</label>"))
                                plcCuerpo.Controls.Add(New LiteralControl("</td>"))
                                plcCuerpo.Controls.Add(New LiteralControl("<td align=center>"))
                                plcCuerpo.Controls.Add(New LiteralControl("<IMG alt=N/A src=picts\Encuesta\Neutral.ico border=0>"))
                                plcCuerpo.Controls.Add(New LiteralControl("<label>n/a</label>"))
                                plcCuerpo.Controls.Add(New LiteralControl("</td>"))
                        End Select
                        plcCuerpo.Controls.Add(New LiteralControl("</tr>"))
                        'plcCuerpo.Controls.Add(New LiteralControl("</thead>")) '' nuevo
                        'plcCuerpo.Controls.Add(New LiteralControl("<br>"))'ok
                        'plcCuerpo.Controls.Add(New LiteralControl("</thead>"))
                        'plcCuerpo.Controls.Add(New LiteralControl("<tbody>"))
                        bEncOpMult = True
                    End If
                    'Fin Construye encabezado de imagenes

                    'Agrega Pregunta
                    'plcCuerpo.Controls.Add(New LiteralControl("<tbody>")) '' nuevo
                    plcCuerpo.Controls.Add(New LiteralControl("<tr>"))
                    plcCuerpo.Controls.Add(New LiteralControl("<td width=600>")) ' width=75%
                    plcCuerpo.Controls.Add(New LiteralControl(CType(oDr.Item("Pregunta"), String)))
                    plcCuerpo.Controls.Add(New LiteralControl("</td>"))
                    'plcCuerpo.Controls.Add(New LiteralControl("</div>"))

                    Dim dtCuerpo3 As DataTable
                    Dim dataCuerpo3 As New DataConn
                    dataCuerpo3.SeccionConnStr = "CadenaConexion"
                    dtCuerpo3 = dataCuerpo3.fncOpcionesPreguntas(CType(oDr.Item("IdPregunta"), Integer), IdEval)
                    Dim oDr3 As DataTableReader = dtCuerpo3.CreateDataReader()

                    While oDr3.Read
                        Dim raBtn As New RadioButton
                        raBtn.Text = ""
                        raBtn.ToolTip = CType(oDr3.Item("Respuesta"), String)
                        raBtn.GroupName = CType(oDr.Item("IdPregunta"), String)

                        If (oDr.Item("IdPregunta") = 198) And (oDr3.Item("NumOpcion") = 2) Then
                            raBtn.Enabled = False
                        End If
                        If (oDr.Item("IdPregunta") = 198) And (oDr3.Item("NumOpcion") = 3) Then
                            raBtn.Enabled = False
                        End If

                        'Else
                        '    raBtn.Enabled = True
                        'End If

                        'plcCuerpo.Controls.Add(New LiteralControl("<td align=center valign=topwidth=6.25%>"))
                        plcCuerpo.Controls.Add(New LiteralControl("<td  width=45 align=center>"))
                        plcCuerpo.Controls.Add(raBtn)
                        If sValida = "" Then
                            sValida = raBtn.ClientID
                        Else
                            sValida = sValida + "," + raBtn.ClientID
                        End If
                        plcCuerpo.Controls.Add(New LiteralControl("</td>"))
                    End While
                    If Not oDr3 Is Nothing Then
                        oDr3.Close()
                        oDr3 = Nothing
                    End If
                    'FIN RESPUESTAS
                    plcCuerpo.Controls.Add(New LiteralControl("</tr>"))
                    'plcCuerpo.Controls.Add(New LiteralControl("</tbody>")) '' nuevo
                    ''''''''''plcCuerpo.Controls.Add(New LiteralControl("</table>"))
                    ''''''''''plcCuerpo.Controls.Add(New LiteralControl("<br>"))
                    ''''''''''plcCuerpo.Controls.Add(New LiteralControl("<br>"))
                    'Fin Agrega Pregunta
                Else 'Preguntas de Tipo Si No

                    plcCuerpo.Controls.Add(New LiteralControl("<table width=100%>"))
                    plcCuerpo.Controls.Add(New LiteralControl("<div class=just>"))
                    'Agrega Pregunta
                    plcCuerpo.Controls.Add(New LiteralControl("<tr>"))
                    plcCuerpo.Controls.Add(New LiteralControl("<td >"))
                    plcCuerpo.Controls.Add(New LiteralControl(CType(oDr.Item("Pregunta"), String)))
                    plcCuerpo.Controls.Add(New LiteralControl("</td>"))
                    plcCuerpo.Controls.Add(New LiteralControl("</div>"))

                    'CONSULTA LAS RESPUESTAS
                    'Dim sqlConn3 As New SqlClient.SqlConnection(sConnString)
                    'Dim oCmd3 As New SqlClient.SqlCommand
                    'Dim oDr3 As SqlClient.SqlDataReader

                    'oCmd3.Connection = sqlConn3
                    'oCmd3.CommandType = CommandType.StoredProcedure
                    'oCmd3.CommandText = "SpSelConsultaOpcionPreguntas"
                    'oCmd3.Parameters.Clear()
                    'oCmd3.Parameters.Add("@IdPregunta", SqlDbType.Int).Value = CType(oDr.Item("IdPregunta"), Integer)
                    'oCmd3.Parameters.Add("@IdCuestionario", SqlDbType.Int).Value = IdEval
                    'sqlConn3.Open()
                    'oDr3 = oCmd3.ExecuteReader()

                    Dim dtCuerpo3 As DataTable
                    Dim dataCuerpo3 As New DataConn
                    dataCuerpo3.SeccionConnStr = "CadenaConexion"
                    dtCuerpo3 = dataCuerpo3.fncOpcionesPreguntas(CType(oDr.Item("IdPregunta"), Integer), IdEval)
                    Dim oDr3 As DataTableReader = dtCuerpo3.CreateDataReader()

                    While oDr3.Read
                        Dim raBtn As New RadioButton
                        raBtn.Text = CType(oDr3.Item("Respuesta"), String)
                        raBtn.ToolTip = CType(oDr3.Item("Respuesta"), String)
                        raBtn.GroupName = CType(oDr.Item("IdPregunta"), String)
                        plcCuerpo.Controls.Add(New LiteralControl("<td align=center valign=top>"))
                        plcCuerpo.Controls.Add(raBtn)
                        sValida = sValida + "," + raBtn.ClientID
                        plcCuerpo.Controls.Add(New LiteralControl("</td>"))
                    End While
                    If Not oDr3 Is Nothing Then
                        oDr3.Close()
                        oDr3 = Nothing
                    End If
                    'sqlConn3.Close()
                    'sqlConn3.Dispose()
                    'FIN RESPUESTAS
                    plcCuerpo.Controls.Add(New LiteralControl("</tr>"))
                    plcCuerpo.Controls.Add(New LiteralControl("</table>"))
                    plcCuerpo.Controls.Add(New LiteralControl("<br>"))
                    plcCuerpo.Controls.Add(New LiteralControl("<br>"))
                    'Fin Agrega Pregunta
                End If
                ConstruyeCuerpo = True
            End While
            'plcCuerpo.Controls.Add(New LiteralControl("</tbody>"))
            plcCuerpo.Controls.Add(New LiteralControl("</table>"))
            Response.Write("<input name='txtvalida' id='txtvalida' type= 'hidden' value = " & sValida)

        Catch ex As Exception
            ConstruyeCuerpo = False
        Finally
            If Not oDr Is Nothing Then
                oDr.Close()
                oDr = Nothing
            End If
            '    sqlConn.Close()
            '    sqlConn.Dispose()
        End Try
    End Function

    Public Function getRadioGroupCheckedRadio(ByRef parentControl As Control, ByVal grpName As String) As RadioButton
        Dim ctl2 As Control
        For Each ctl As Control In parentControl.Controls
            If ctl.GetType Is GetType(RadioButton) Then
                If CType(ctl, RadioButton).GroupName = grpName Then
                    If CType(ctl, RadioButton).Checked Then
                        getRadioGroupCheckedRadio = ctl
                        Exit Function
                    End If
                    ctl2 = ctl
                End If
            End If
        Next
        getRadioGroupCheckedRadio = ctl2

    End Function

    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click

        '---ScriptManager.RegisterStartupScript(Me, Page.GetType, "Javascript", "javascript:deletePost()", True)
        '---ClientScript.RegisterClientScriptBlock(Me.GetType, "Javascript", "Javascript:alert('Esta captura ya existe')", True)
        '---ClientScript.RegisterClientScriptBlock(Me.GetType, "Script", "deletePost()", True)

        ClientScript.RegisterStartupScript(Me.GetType(), "alert", "Redirect();", True)

        'If (Not ClientScript.IsStartupScriptRegistered("alert")) Then
        '    Page.ClientScript.RegisterStartupScript _
        '    (Me.GetType(), "alert", "Redirect();", True)
        'End If

        'Dim dato As String = Me.plcCuerpo.Controls.Count
        'Dim dato2 As String = Me.plcTitulo.Controls.Count()
        'Dim dato3 As String = Me.plcInstruccion.Controls.Count()

        'Dim sTipo, sOpcion, sRespuesta, sSexo, sUbicacion, sEstudias, sHotel
        'Dim IdPregunta, iCuestionario, iEdad, idEval As Integer
        'Dim iAnio, iPeriodo, iSexo As Integer

        'Dim IdEmpleado As String, IdEmpleado_2 As String, IdEmpleado_3 As String
        'Dim Empleado As String, Empleado_2 As String, Empleado_3 As String

        'Dim IdEmpleadoEjemploSeguir As String, IdEmpleadoEjemploSeguir_2 As String, IdEmpleadoEjemploSeguir_3 As String
        'Dim EmpleadoEjemploSeguir As String, EmpleadoEjemploSeguir_2 As String, EmpleadoEjemploSeguir_3 As String

        'Dim IdEmpleadoOrganizaDeportes As String, IdEmpleadoOrganizaDeportes_2 As String, IdEmpleadoOrganizaDeportes_3 As String
        'Dim EmpleadoOrganizaDeportes As String, EmpleadoOrganizaDeportes_2 As String, EmpleadoOrganizaDeportes_3 As String

        'System.Threading.Thread.Sleep(5000)

        'If Page.IsValid Then

        '    iCuestionario = cboCuestionario.SelectedValue
        '    sHotel = cboHotel.SelectedValue
        '    iAnio = cboAnio.SelectedValue
        '    iPeriodo = cboPeriodo.SelectedValue
        '    iSexo = cboSexo.SelectedValue
        '    idEval = 0 'CInt(txtFolio.Text)

        '    Empleado = Me.txtProspectoJefe.Text
        '    IdEmpleado = Me.HddnIdEmpleado.Value
        '    If Empleado <> "" Then
        '        If IdEmpleado = "0" Then
        '            If diccJefeProspecto.ContainsKey(Empleado) Then
        '                Dim idJefeProspecto As Integer = diccJefeProspecto(Empleado)
        '                Me.HddnIdEmpleado.Value = idJefeProspecto
        '            Else
        '                Me.HddnIdEmpleado.Value = 0
        '            End If
        '        End If
        '    End If
        '    Empleado_2 = Me.txtProspectoJefe_2.Text
        '    IdEmpleado_2 = Me.HddnIdEmpleado_2.Value
        '    If Empleado_2 <> "" Then
        '        If IdEmpleado_2 = "0" Then
        '            If diccJefeProspecto_2.ContainsKey(Empleado_2) Then
        '                Dim idJefeProspecto As Integer = diccJefeProspecto_2(Empleado_2)
        '                Me.HddnIdEmpleado_2.Value = idJefeProspecto
        '            Else
        '                Me.HddnIdEmpleado_2.Value = 0
        '            End If
        '        End If
        '    End If
        '    Empleado_3 = Me.txtProspectoJefe_3.Text
        '    IdEmpleado_3 = Me.HddnIdEmpleado_3.Value
        '    If Empleado_3 <> "" Then
        '        If IdEmpleado_3 = "0" Then
        '            If diccJefeProspecto_3.ContainsKey(Empleado_3) Then
        '                Dim idJefeProspecto As Integer = diccJefeProspecto_3(Empleado_3)
        '                Me.HddnIdEmpleado_3.Value = idJefeProspecto
        '            Else
        '                Me.HddnIdEmpleado_3.Value = 0
        '            End If
        '        End If
        '    End If

        '    EmpleadoEjemploSeguir = Me.txtEjemploSeguir.Text
        '    IdEmpleadoEjemploSeguir = Me.HddIdEmpleadoEjemploSeguirI.Value
        '    If EmpleadoEjemploSeguir <> "" Then
        '        If IdEmpleadoEjemploSeguir = "0" Then
        '            If diccEjemploASeguir.ContainsKey(EmpleadoEjemploSeguir) Then
        '                Dim idJefeProspecto As Integer = diccEjemploASeguir(EmpleadoEjemploSeguir)
        '                Me.HddIdEmpleadoEjemploSeguirI.Value = idJefeProspecto
        '            Else
        '                Me.HddIdEmpleadoEjemploSeguirI.Value = 0
        '            End If
        '        End If
        '    End If
        '    EmpleadoEjemploSeguir_2 = Me.txtEjemploSeguir_2.Text
        '    IdEmpleadoEjemploSeguir_2 = Me.HddIdEmpleadoEjemploSeguirII.Value
        '    If EmpleadoEjemploSeguir_2 <> "" Then
        '        If IdEmpleadoEjemploSeguir_2 = "0" Then
        '            If diccEjemploASeguir_2.ContainsKey(EmpleadoEjemploSeguir_2) Then
        '                Dim idJefeProspecto As Integer = diccEjemploASeguir_2(EmpleadoEjemploSeguir_2)
        '                Me.HddIdEmpleadoEjemploSeguirII.Value = idJefeProspecto
        '            Else
        '                Me.HddIdEmpleadoEjemploSeguirII.Value = 0
        '            End If
        '        End If
        '    End If
        '    EmpleadoEjemploSeguir_3 = Me.txtEjemploSeguir_3.Text
        '    IdEmpleadoEjemploSeguir_3 = Me.HddIdEmpleadoEjemploSeguirIII.Value
        '    If EmpleadoEjemploSeguir_3 <> "" Then
        '        If IdEmpleadoEjemploSeguir_3 = "0" Then
        '            If diccEjemploASeguir_3.ContainsKey(EmpleadoEjemploSeguir_3) Then
        '                Dim idJefeProspecto As Integer = diccEjemploASeguir_3(EmpleadoEjemploSeguir_3)
        '                Me.HddIdEmpleadoEjemploSeguirIII.Value = idJefeProspecto
        '            Else
        '                Me.HddIdEmpleadoEjemploSeguirIII.Value = 0
        '            End If
        '        End If
        '    End If

        '    EmpleadoOrganizaDeportes = Me.txtOrganizaDeportes.Text
        '    IdEmpleadoOrganizaDeportes = Me.HddnEmpleadoOrganizaReportesI.Value
        '    If EmpleadoOrganizaDeportes <> "" Then
        '        If IdEmpleadoOrganizaDeportes = "0" Then
        '            If diccOrganizaDeportes.ContainsKey(EmpleadoOrganizaDeportes) Then
        '                Dim idJefeProspecto As Integer = diccOrganizaDeportes(EmpleadoOrganizaDeportes)
        '                Me.HddnEmpleadoOrganizaReportesI.Value = idJefeProspecto
        '            Else
        '                Me.HddnEmpleadoOrganizaReportesI.Value = 0
        '            End If
        '        End If
        '    End If
        '    EmpleadoOrganizaDeportes_2 = Me.txtOrganizaDeportes_2.Text
        '    IdEmpleadoOrganizaDeportes_2 = Me.HddnEmpleadoOrganizaReportesII.Value
        '    If EmpleadoOrganizaDeportes_2 <> "" Then
        '        If IdEmpleadoOrganizaDeportes_2 = "0" Then
        '            If diccOrganizaDeportes_2.ContainsKey(EmpleadoOrganizaDeportes_2) Then
        '                Dim idJefeProspecto As Integer = diccOrganizaDeportes_2(EmpleadoOrganizaDeportes_2)
        '                Me.HddnEmpleadoOrganizaReportesII.Value = idJefeProspecto
        '            Else
        '                Me.HddnEmpleadoOrganizaReportesII.Value = 0
        '            End If
        '        End If
        '    End If
        '    EmpleadoOrganizaDeportes_3 = Me.txtOrganizaDeportes_3.Text
        '    IdEmpleadoOrganizaDeportes_3 = Me.HddnEmpleadoOrganizaReportesIII.Value
        '    If EmpleadoOrganizaDeportes_3 <> "" Then
        '        If IdEmpleadoOrganizaDeportes_3 = "0" Then
        '            If diccOrganizaDeportes_3.ContainsKey(EmpleadoOrganizaDeportes_3) Then
        '                Dim idJefeProspecto As Integer = diccOrganizaDeportes_3(EmpleadoOrganizaDeportes_3)
        '                Me.HddnEmpleadoOrganizaReportesIII.Value = idJefeProspecto
        '            Else
        '                Me.HddnEmpleadoOrganizaReportesIII.Value = 0
        '            End If
        '        End If
        '    End If

        '    Dim sUser As String = Thread.CurrentPrincipal.Identity.Name.Substring(Thread.CurrentPrincipal.Identity.Name.IndexOf("\") + 1)

        '    'InsertaEncabezado(idEval)

        '    'If IdEmpleado <> "0" And IdEmpleadoEjemploSeguir <> "0" And IdEmpleadoOrganizaDeportes <> "0" Then
        '    'If Empleado <> "" And EmpleadoEjemploSeguir <> "" And IdEmpleadoOrganizaDeportes <> "" Then
        '    Dim dataEncabezado As New DataConn
        '    dataEncabezado.SeccionConnStr = "CadenaConexion"
        '    Dim insert As Integer

        '    insert = dataEncabezado.fncInsertaEncabezado(idEval, iCuestionario, sHotel, iAnio, iPeriodo, iSexo, sUser)

        '    If insert <> 0 Then '= 1 Then
        '        '-- Nuevo ----
        '        '--- Jefe Prospecto I ---
        '        If Empleado <> "" Then
        '            dataEncabezado.fncInsertaEncabezadoJefesProspecto(insert, iCuestionario, sHotel, iAnio, iPeriodo, IdEmpleado, Empleado)
        '        End If
        '        '--- Jefe Prospecto II ---
        '        If Empleado_2 <> "" Then
        '            dataEncabezado.fncInsertaEncabezadoJefesProspecto(insert, iCuestionario, sHotel, iAnio, iPeriodo, IdEmpleado_2, Empleado_2)
        '        End If
        '        '--- Jefe Prospecto III ---
        '        If Empleado_3 <> "" Then
        '            dataEncabezado.fncInsertaEncabezadoJefesProspecto(insert, iCuestionario, sHotel, iAnio, iPeriodo, IdEmpleado_3, Empleado_3)
        '        End If

        '        If EmpleadoEjemploSeguir <> "" Then
        '            dataEncabezado.fncInsertaEncabezadoEjemplo_Seguir(insert, iCuestionario, sHotel, iAnio, iPeriodo, IdEmpleadoEjemploSeguir, EmpleadoEjemploSeguir)
        '        End If
        '        If EmpleadoEjemploSeguir_2 <> "" Then
        '            dataEncabezado.fncInsertaEncabezadoEjemplo_Seguir(insert, iCuestionario, sHotel, iAnio, iPeriodo, IdEmpleadoEjemploSeguir_2, EmpleadoEjemploSeguir_2)
        '        End If
        '        If EmpleadoEjemploSeguir_3 <> "" Then
        '            dataEncabezado.fncInsertaEncabezadoEjemplo_Seguir(insert, iCuestionario, sHotel, iAnio, iPeriodo, IdEmpleadoEjemploSeguir_3, EmpleadoEjemploSeguir_3)
        '        End If

        '        If EmpleadoOrganizaDeportes <> "" Then
        '            dataEncabezado.fncInsertaEncabezadoOrganiza_Deportes_Actividades(insert, iCuestionario, sHotel, iAnio, iPeriodo, IdEmpleadoOrganizaDeportes, EmpleadoOrganizaDeportes)
        '        End If
        '        If EmpleadoOrganizaDeportes_2 <> "" Then
        '            dataEncabezado.fncInsertaEncabezadoOrganiza_Deportes_Actividades(insert, iCuestionario, sHotel, iAnio, iPeriodo, IdEmpleadoOrganizaDeportes_2, EmpleadoOrganizaDeportes_2)
        '        End If
        '        If EmpleadoOrganizaDeportes_3 <> "" Then
        '            dataEncabezado.fncInsertaEncabezadoOrganiza_Deportes_Actividades(insert, iCuestionario, sHotel, iAnio, iPeriodo, IdEmpleadoOrganizaDeportes_3, EmpleadoOrganizaDeportes_3)
        '        End If
        '        '-------------

        '        idEval = insert
        '        Dim dtEnviar As DataTable
        '        Dim dataEnviar As New DataConn
        '        dataEnviar.SeccionConnStr = "CadenaConexion"
        '        'dtEnviar = dataEnviar.fncPreguntasEncuesta(iCuestionario)
        '        dtEnviar = dataEnviar.fncPreguntasEncuestaxHotel(Me.cboHotel.SelectedValue, iCuestionario)
        '        Dim oDr As DataTableReader = dtEnviar.CreateDataReader()
        '        Dim tot As Integer = dtEnviar.Rows.Count
        '        Dim i As Integer = 0

        '        Try
        '            While oDr.Read
        '                sTipo = oDr.Item("Tipo")
        '                IdPregunta = oDr.Item("IdPregunta")
        '                If sTipo.ToUpper.IndexOf("ABIERTA") > 0 Then
        '                    sRespuesta = CType(Me.plcCuerpo.FindControl(CType(IdPregunta, String)), TextBox).Text.Trim
        '                Else
        '                    Dim valor As String = Me.plcCuerpo.Controls.Count


        '                    Dim raBtn As RadioButton = getRadioGroupCheckedRadio(Me.plcCuerpo, CType(IdPregunta, String))
        '                    sRespuesta = raBtn.ToolTip
        '                End If
        '                If sRespuesta.Length > 0 Then InsertaRespuesta(iCuestionario, IdPregunta, sRespuesta, idEval)

        '                i = i + 1

        '                If tot = i Then
        '                    'ClientScript.RegisterClientScriptBlock(Me.GetType, "alert", "alert('los datos se guardaron con éxito')", True)'no jala
        '                    'Response.Write("<script language='javascript'>alert('Los datos se guardaron con exito');</script>")' no jala
        '                    'Response.Write("<script language='javascript'>window.alert('Database updated.');</script>")
        '                    'esponse.Write(" <asp:Label ID='Label3' runat='server' Text='Database updated.' Font-Bold='true' Font-Size='X-Large' CssClass='StrongText'></asp:Label>")
        '                    'Response.Write("<h1 align=""center"">Database updated.</h1>")
        '                    'ClientScript.RegisterClientScriptBlock(Me.GetType, "alert", "alert('Database updated II.')", True)
        '                End If

        '            End While



        '        Catch ex As Exception
        '            'utilerias.creaMensaje(Me.Page, "Hubo un error al almacenar sus respuestas en la Base de Datos,\n" & _
        '            '" por favor comuníquese al Departamento de Base de datos.\nError: " & ex.Message, "alertKey")
        '        Finally
        '            If Not oDr Is Nothing Then
        '                oDr.Close()
        '                oDr = Nothing
        '            End If
        '            'sqlConn.Close()
        '            'sqlConn.Dispose()
        '            Me.enviar = 1
        '            Call btnLimpiar_Click(sender, e)

        '        End Try
        '    Else
        '        ClientScript.RegisterClientScriptBlock(Me.GetType, "alert", "alert('Esta captura ya existe')", True)
        '    End If

        '    'Dim dataEncabezado As New DataConn
        '    'dataEncabezado.SeccionConnStr = "CadenaConexion"
        '    'Dim insert As Integer

        '    'insert = dataEncabezado.fncInsertaEncabezado(idEval, iCuestionario, sHotel, iAnio, iPeriodo, iSexo, sUser)

        '    'If insert <> 0 Then '= 1 Then
        '    '    idEval = insert
        '    '    Dim dtEnviar As DataTable
        '    '    Dim dataEnviar As New DataConn
        '    '    dataEnviar.SeccionConnStr = "CadenaConexion"
        '    '    'dtEnviar = dataEnviar.fncPreguntasEncuesta(iCuestionario)
        '    '    dtEnviar = dataEnviar.fncPreguntasEncuestaxHotel(Me.cboHotel.SelectedValue, iCuestionario)
        '    '    Dim oDr As DataTableReader = dtEnviar.CreateDataReader()
        '    '    Dim tot As Integer = dtEnviar.Rows.Count
        '    '    Dim i As Integer = 0

        '    '    Try
        '    '        While oDr.Read
        '    '            sTipo = oDr.Item("Tipo")
        '    '            IdPregunta = oDr.Item("IdPregunta")
        '    '            If sTipo.ToUpper.IndexOf("ABIERTA") > 0 Then
        '    '                sRespuesta = CType(Me.plcCuerpo.FindControl(CType(IdPregunta, String)), TextBox).Text.Trim
        '    '            Else
        '    '                Dim valor As String = Me.plcCuerpo.Controls.Count


        '    '                Dim raBtn As RadioButton = getRadioGroupCheckedRadio(Me.plcCuerpo, CType(IdPregunta, String))
        '    '                sRespuesta = raBtn.ToolTip
        '    '            End If
        '    '            If sRespuesta.Length > 0 Then InsertaRespuesta(iCuestionario, IdPregunta, sRespuesta, idEval)

        '    '            i = i + 1

        '    '            If tot = i Then
        '    '                'ClientScript.RegisterClientScriptBlock(Me.GetType, "alert", "alert('los datos se guardaron con éxito')", True)'no jala
        '    '                'Response.Write("<script language='javascript'>alert('Los datos se guardaron con exito');</script>")' no jala
        '    '                'Response.Write("<script language='javascript'>window.alert('Database updated.');</script>")
        '    '                'esponse.Write(" <asp:Label ID='Label3' runat='server' Text='Database updated.' Font-Bold='true' Font-Size='X-Large' CssClass='StrongText'></asp:Label>")
        '    '                'Response.Write("<h1 align=""center"">Database updated.</h1>")
        '    '                'ClientScript.RegisterClientScriptBlock(Me.GetType, "alert", "alert('Database updated II.')", True)
        '    '            End If

        '    '        End While
        '    '    Catch ex As Exception
        '    '        'utilerias.creaMensaje(Me.Page, "Hubo un error al almacenar sus respuestas en la Base de Datos,\n" & _
        '    '        '" por favor comuníquese al Departamento de Base de datos.\nError: " & ex.Message, "alertKey")
        '    '    Finally
        '    '        If Not oDr Is Nothing Then
        '    '            oDr.Close()
        '    '            oDr = Nothing
        '    '        End If
        '    '        'sqlConn.Close()
        '    '        'sqlConn.Dispose()
        '    '        Me.enviar = 1
        '    '        Call btnLimpiar_Click(sender, e)

        '    '    End Try

        '    'Else
        '    'Response.Write("<script language='javascript'>alert('Captura el dato faltante');</script>")
        '    'Response.Write("<script languaje='javascript'>alert('Los datos Ingresados ya existen');</script>")
        '    'ClientScript.RegisterClientScriptBlock(Me.GetType, "alert", "alert('Faltan algunos campos de completar')", True)

        '    'Response.Write("<h1 align=""center"">La captura ya existe.</h1>") '""center""

        '    '----- PROSPECTO JEFE ------
        '    'IdEmpleado = Me.HddnIdEmpleado.Value
        '    'If IdEmpleado = "0" Then
        '    '    Me.txtProspectoJefe.Text = ""
        '    'End If

        '    'IdEmpleado_2 = Me.HddnIdEmpleado_2.Value
        '    'If IdEmpleado_2 = "0" Then
        '    '    Me.txtProspectoJefe_2.Text = ""
        '    'End If

        '    'IdEmpleado_3 = Me.HddnIdEmpleado_3.Value
        '    'If IdEmpleado_3 = "0" Then
        '    '    Me.txtProspectoJefe_3.Text = ""
        '    'End If

        '    ''------ PROSPECTO A SEGUIR ------
        '    'IdEmpleadoEjemploSeguir = Me.HddIdEmpleadoEjemploSeguirI.Value
        '    'If IdEmpleadoEjemploSeguir = "0" Then
        '    '    Me.txtEjemploSeguir.Text = ""
        '    'End If

        '    'IdEmpleadoEjemploSeguir_2 = Me.HddIdEmpleadoEjemploSeguirII.Value
        '    'If IdEmpleadoEjemploSeguir_2 = "0" Then
        '    '    Me.txtEjemploSeguir_2.Text = ""
        '    'End If

        '    'IdEmpleadoEjemploSeguir_3 = Me.HddIdEmpleadoEjemploSeguirIII.Value
        '    'If IdEmpleadoEjemploSeguir_3 = "0" Then
        '    '    Me.txtEjemploSeguir_3.Text = ""
        '    'End If

        '    ''----- ORGANIZA DEPORTES ------
        '    'IdEmpleadoOrganizaDeportes = Me.HddnEmpleadoOrganizaReportesI.Value
        '    'If IdEmpleadoOrganizaDeportes = "0" Then
        '    '    Me.txtOrganizaDeportes.Text = ""
        '    'End If

        '    'IdEmpleadoOrganizaDeportes_2 = Me.HddnEmpleadoOrganizaReportesII.Value
        '    'If IdEmpleadoOrganizaDeportes_2 = "0" Then
        '    '    Me.txtOrganizaDeportes_2.Text = ""
        '    'End If

        '    'IdEmpleadoOrganizaDeportes_3 = Me.HddnEmpleadoOrganizaReportesIII.Value
        '    'If IdEmpleadoOrganizaDeportes_3 = "0" Then
        '    '    Me.txtOrganizaDeportes_3.Text = ""
        '    'End If

        '    ' End If
        'End If
    End Sub

    Private Sub InsertaEncabezado(ByVal IdEval As Integer)
        Dim sHotel As String
        Dim iCuestionario, iAnio, iPeriodo, iSexo, iFolio As Integer
        'Dim sqlConnIns As New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("ConnEvalClimaLab"))
        'Dim oCmdIns As New SqlClient.SqlCommand

        Dim sUser As String = Thread.CurrentPrincipal.Identity.Name.Substring(Thread.CurrentPrincipal.Identity.Name.IndexOf("\") + 1)

        If sUser Is Nothing Then Dim sIp As String = Request.ServerVariables("REMOTE_ADDR")
        If Not sUser Is Nothing Then If sUser.Trim.Length <= 0 Then Dim sIp As String = Request.ServerVariables("REMOTE_ADDR")

        iCuestionario = cboCuestionario.SelectedValue
        sHotel = cboHotel.SelectedValue
        iAnio = cboAnio.SelectedValue
        iPeriodo = cboPeriodo.SelectedValue
        iSexo = cboSexo.SelectedValue

        Dim dataEncabezado As New DataConn
        dataEncabezado.SeccionConnStr = "CadenaConexion"
        dataEncabezado.fncInsertaEncabezado(IdEval, iCuestionario, sHotel, iAnio, iPeriodo, iSexo, sUser)

        'sqlConnIns.Open()
        'oCmdIns.Connection = sqlConnIns
        'oCmdIns.CommandText = "SpInsEncabezado"
        'oCmdIns.CommandType = CommandType.StoredProcedure
        'oCmdIns.Parameters.Clear()

        'Dim pFolio As New SqlClient.SqlParameter("@IdEval", SqlDbType.Int)
        'pFolio.Value = IdEval
        'oCmdIns.Parameters.Add(pFolio)

        'Dim pIdCuestionario As New SqlClient.SqlParameter("@IdCuestionario", SqlDbType.Int)
        'pIdCuestionario.Value = iCuestionario
        'oCmdIns.Parameters.Add(pIdCuestionario)


        'Dim pHotel As New SqlClient.SqlParameter("@IdHotel", SqlDbType.VarChar, 25)
        'pHotel.Value = sHotel
        'oCmdIns.Parameters.Add(pHotel)

        'Dim pAnio As New SqlClient.SqlParameter("@Anio", SqlDbType.Int)
        'pAnio.Value = iAnio
        'oCmdIns.Parameters.Add(pAnio)

        'Dim pPeriodo As New SqlClient.SqlParameter("@IdPeriodo", SqlDbType.Int)
        'pPeriodo.Value = iPeriodo
        'oCmdIns.Parameters.Add(pPeriodo)

        'Dim pSexo As New SqlClient.SqlParameter("@IdSexo", SqlDbType.Int)
        'pSexo.Value = iSexo
        'oCmdIns.Parameters.Add(pSexo)


        'Dim pUsuario As New SqlClient.SqlParameter("@IdUsuario", SqlDbType.VarChar, 20)
        'pUsuario.Value = sUser
        'oCmdIns.Parameters.Add(pUsuario)

        'oCmdIns.ExecuteNonQuery()

        'sqlConnIns.Close()

        'pIdCuestionario = Nothing
        'pSexo = Nothing
        'pPeriodo = Nothing
        'pAnio = Nothing
        'pHotel = Nothing
        'pUsuario = Nothing

    End Sub

    Private Sub InsertaRespuesta(ByVal IdCuestionario As Integer, ByVal IdPregunta As Integer, ByVal sRespuesta As String, _
        ByVal idEval As Integer)

        Dim dataInserta As New DataConn
        dataInserta.SeccionConnStr = "CadenaConexion"
        dataInserta.FncInsertaRespuesta(IdCuestionario, IdPregunta, sRespuesta, idEval, sRespuesta, cboHotel.SelectedValue)

        'Dim sqlConnIns As New SqlClient.SqlConnection(ConfigurationSettings.AppSettings("ConnEvalClimaLab"))
        'Dim oCmdIns As New SqlClient.SqlCommand

        'sqlConnIns.Open()
        'oCmdIns.Connection = sqlConnIns
        'oCmdIns.CommandText = "SpInsRespuesta"
        'oCmdIns.CommandType = CommandType.StoredProcedure
        'oCmdIns.Parameters.Clear()

        'Dim pIdCuestionario As New SqlClient.SqlParameter("@IdCuestionario", SqlDbType.Int)
        'pIdCuestionario.Value = IdCuestionario
        'oCmdIns.Parameters.Add(pIdCuestionario)

        'Dim pIdPregunta As New SqlClient.SqlParameter("@IdPregunta", SqlDbType.Int)
        'pIdPregunta.Value = IdPregunta
        'oCmdIns.Parameters.Add(pIdPregunta)

        'Dim pRespuesta As New SqlClient.SqlParameter("@Respuesta", SqlDbType.Text)
        'pRespuesta.Value = sRespuesta
        'oCmdIns.Parameters.Add(pRespuesta)


        'Dim pIdEval As New SqlClient.SqlParameter("@IdEval", SqlDbType.Int)
        'pIdEval.Value = idEval
        'oCmdIns.Parameters.Add(pIdEval)

        'Dim pRespuestaOpM As New SqlClient.SqlParameter("@RespuestaOpM", SqlDbType.VarChar, 600)
        'pRespuestaOpM.Value = sRespuesta
        'oCmdIns.Parameters.Add(pRespuestaOpM)

        'Dim pHotel As New SqlClient.SqlParameter("@Idhotel", SqlDbType.VarChar, 25)
        'pHotel.Value = cboHotel.SelectedValue
        'oCmdIns.Parameters.Add(pHotel)


        'oCmdIns.ExecuteNonQuery()

        'sqlConnIns.Close()

        'pIdCuestionario = Nothing
        'pIdPregunta = Nothing
        'pRespuesta = Nothing
        'pIdEval = Nothing
        'pRespuestaOpM = Nothing
        'pHotel = Nothing

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        If IsPostBack() Then
            If Context.Items("Transferred") Is Nothing Then
                'Initialize to prevent stackover 
                Context.Items("Transferred") = New Object
                'TransferToSelf 
                Server.Transfer("ClimaLab.aspx?Saved=1")
            End If
        End If
    End Sub

    Protected Sub cboCuestionario_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCuestionario.SelectedIndexChanged
        Response.Redirect("ClimaLab.aspx?Eval=" & cboCuestionario.SelectedValue)
    End Sub

    Protected Sub cboHotel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboHotel.SelectedIndexChanged

        idhotelCmboHotel = cboHotel.SelectedValue
        'actualizaListaJefe = True

        ''str = "Select Idhotel_Dataware from Hoteles where Idhotel = '" + shotel + "'"

        'Dim dtHotel As DataTable
        'Dim dataHotel As New DataConn
        'dataHotel.SeccionConnStr = "CadenaConexion"
        'dtHotel = dataHotel.fncSelJefes(Me.cboHotel.SelectedValue)

        'If dtHotel.Rows.Count Then
        '    cboSexo.DataSource = dtHotel
        '    cboSexo.DataTextField = "Nombre"
        '    cboSexo.DataValueField = "IdUsuario"
        '    cboSexo.DataBind()
        'End If

        ''nuevo
        'Dim dtCuestionario As New DataTable
        'Dim dataCuestionario As New DataConn
        'dataCuestionario.SeccionConnStr = "CadenaConexion"
        'dtCuestionario = dataCuestionario.fncSelCuestionarios(Me.cboHotel.SelectedValue)
        'If dtCuestionario.Rows.Count > 0 Then
        '    cboCuestionario.DataSource = dtCuestionario
        '    cboCuestionario.DataTextField = "Titulo"
        '    cboCuestionario.DataValueField = "IdCuestionario"
        '    cboCuestionario.DataBind()
        'End If

        'If Me.cboCuestionario.Items.Count > 0 Then
        '    If Request.QueryString("Eval") Is Nothing Then
        '        GeneraEvaluacion(cboCuestionario.SelectedValue)
        '    Else
        '        cboCuestionario.SelectedValue = Request.QueryString("Eval")
        '        GeneraEvaluacion(Request.QueryString("Eval"))
        '    End If
        'End If

        ''Dim sConnString As String = ConfigurationSettings.AppSettings("ConnEvalClimaLab")
        ''Dim sqlConn As New SqlClient.SqlConnection(sConnString)

        'Dim shotel, str, valor As String

        'shotel = cboHotel.SelectedValue

        'If shotel = "AAAAAAA" Then
        '    cboSexo.Items.Clear()
        'Else
        '    str = "Select Idhotel_Dataware from Hoteles where Idhotel = '" + shotel + "'"

        '    'Dim oCmd2 As New SqlClient.SqlCommand
        '    'oCmd2.Connection = sqlConn
        '    'oCmd2.CommandText = str

        '    'sqlConn.Open()
        '    'valor = oCmd2.ExecuteScalar
        '    'sqlConn.Close()

        '    'Dim oCmd As New SqlClient.SqlCommand
        '    'oCmd.Connection = sqlConn
        '    'oCmd.Parameters.Clear()
        '    'oCmd.CommandText = "SpSelJefe"
        '    'oCmd.CommandType = CommandType.StoredProcedure

        '    'Dim pHotel As New SqlClient.SqlParameter("@IdHotel", SqlDbType.VarChar, 15)
        '    'pHotel.Value = valor
        '    'oCmd.Parameters.Add(pHotel)

        '    'sqlConn.Open()

        '    'GeneraEvaluacion(cboCuestionario.SelectedValue)

        '    Dim dtHotel As DataTable
        '    Dim dataHotel As New DataConn
        '    dataHotel.SeccionConnStr = "CadenaConexion"
        '    dtHotel = dataHotel.fncSelJefes(shotel)

        '    If dtHotel.Rows.Count Then
        '        cboSexo.DataSource = dtHotel
        '        cboSexo.DataTextField = "Nombre"
        '        cboSexo.DataValueField = "IdUsuario"
        '        cboSexo.DataBind()
        '    End If

        '    'nuevo
        '    Dim dtCuestionario As New DataTable
        '    Dim dataCuestionario As New DataConn
        '    dataCuestionario.SeccionConnStr = "CadenaConexion"
        '    dtCuestionario = dataCuestionario.fncSelCuestionarios(Me.cboHotel.SelectedValue)
        '    If dtCuestionario.Rows.Count > 0 Then
        '        cboCuestionario.DataSource = dtCuestionario
        '        cboCuestionario.DataTextField = "Titulo"
        '        cboCuestionario.DataValueField = "IdCuestionario"
        '        cboCuestionario.DataBind()
        '    End If

        '    'sqlConn.Close()
        '    'Response.Redirect("ClimaLab.aspx?Eval=" & cboCuestionario.SelectedValue)
        'End If


    End Sub

    '--- 30/Enero/2017
    Protected Sub setIdAgrupacion(ByVal sender As Object, ByVal e As EventArgs)

        Dim jefeProspecto As String = Me.txtProspectoJefe.Text

        'diccProspectoJefe.Add(oReader("nombre_completo").ToString(), oReader("idempleado").ToString())

        If diccJefeProspecto.ContainsKey(jefeProspecto) Then
            Dim idJefeProspecto As Integer = diccJefeProspecto(jefeProspecto)
            Me.HddnIdEmpleado.Value = idJefeProspecto
        Else
            Me.HddnIdEmpleado.Value = 0
        End If

        '    Dim agrupacion As String = Me.txtAgrupacion.Text

        '    If diccAgrupaciones.ContainsKey(agrupacion) Then
        '        Dim idAgrupacion As Integer = diccAgrupaciones(agrupacion)
        '        HddnIdAgrupacion.Value = idAgrupacion.ToString()
        '    Else
        '        HddnIdAgrupacion.Value = "0"
        '    End If
    End Sub

    Protected Sub setIdAgrupacion_2(ByVal sender As Object, ByVal e As EventArgs)

        Dim jefeProspecto As String = Me.txtProspectoJefe_2.Text

        'diccProspectoJefe.Add(oReader("nombre_completo").ToString(), oReader("idempleado").ToString())

        If diccJefeProspecto_2.ContainsKey(jefeProspecto) Then
            Dim idJefeProspecto As Integer = diccJefeProspecto_2(jefeProspecto)
            Me.HddnIdEmpleado_2.Value = idJefeProspecto
        Else
            Me.HddnIdEmpleado_2.Value = 0
        End If

        '    Dim agrupacion As String = Me.txtAgrupacion.Text

        '    If diccAgrupaciones.ContainsKey(agrupacion) Then
        '        Dim idAgrupacion As Integer = diccAgrupaciones(agrupacion)
        '        HddnIdAgrupacion.Value = idAgrupacion.ToString()
        '    Else
        '        HddnIdAgrupacion.Value = "0"
        '    End If
    End Sub

    Protected Sub setIdAgrupacion_3(ByVal sender As Object, ByVal e As EventArgs)

        Dim jefeProspecto As String = Me.txtProspectoJefe_3.Text

        'diccProspectoJefe.Add(oReader("nombre_completo").ToString(), oReader("idempleado").ToString())

        If diccJefeProspecto_3.ContainsKey(jefeProspecto) Then
            Dim idJefeProspecto As Integer = diccJefeProspecto_3(jefeProspecto)
            Me.HddnIdEmpleado_3.Value = idJefeProspecto
        Else
            Me.HddnIdEmpleado_3.Value = 0
        End If

        '    Dim agrupacion As String = Me.txtAgrupacion.Text

        '    If diccAgrupaciones.ContainsKey(agrupacion) Then
        '        Dim idAgrupacion As Integer = diccAgrupaciones(agrupacion)
        '        HddnIdAgrupacion.Value = idAgrupacion.ToString()
        '    Else
        '        HddnIdAgrupacion.Value = "0"
        '    End If
    End Sub


    Protected Sub setIdEmpleadoEjemploSeguirI(ByVal sender As Object, ByVal e As EventArgs)

        Dim ejemploSeguir As String = Me.txtEjemploSeguir.Text

        If diccEjemploASeguir.ContainsKey(ejemploSeguir) Then
            Dim idEjemploSeguir As Integer = diccEjemploASeguir(ejemploSeguir)
            Me.HddIdEmpleadoEjemploSeguirI.Value = idEjemploSeguir
        Else
            Me.HddIdEmpleadoEjemploSeguirI.Value = 0
        End If

    End Sub

    Protected Sub setIdEmpleadoEjemploSeguirII(ByVal sender As Object, ByVal e As EventArgs)

        Dim ejemploSeguir As String = Me.txtEjemploSeguir_2.Text

        If diccEjemploASeguir_2.ContainsKey(ejemploSeguir) Then
            Dim idEjemploSeguir As Integer = diccEjemploASeguir_2(ejemploSeguir)
            Me.HddIdEmpleadoEjemploSeguirII.Value = idEjemploSeguir
        Else
            Me.HddIdEmpleadoEjemploSeguirII.Value = 0
        End If

    End Sub

    Protected Sub setIdEmpleadoEjemploSeguirIII(ByVal sender As Object, ByVal e As EventArgs)

        Dim ejemploSeguir As String = Me.txtEjemploSeguir_3.Text

        If diccEjemploASeguir_3.ContainsKey(ejemploSeguir) Then
            Dim idEjemploSeguir As Integer = diccEjemploASeguir_3(ejemploSeguir)
            Me.HddIdEmpleadoEjemploSeguirIII.Value = idEjemploSeguir
        Else
            Me.HddIdEmpleadoEjemploSeguirIII.Value = 0
        End If

    End Sub

    Protected Sub setIdEmpleadoorganizaReportesI(ByVal sender As Object, ByVal e As EventArgs)

        Dim organizaDeportes As String = Me.txtOrganizaDeportes.Text

        If diccOrganizaDeportes.ContainsKey(organizaDeportes) Then
            Dim idOrganizaDeportes As Integer = diccOrganizaDeportes(organizaDeportes)
            Me.HddnEmpleadoOrganizaReportesI.Value = idOrganizaDeportes
        Else
            Me.HddnEmpleadoOrganizaReportesI.Value = 0
        End If

    End Sub

    Protected Sub setIdEmpleadoorganizaReportesII(ByVal sender As Object, ByVal e As EventArgs)

        Dim organizaDeportes As String = Me.txtOrganizaDeportes_2.Text

        If diccOrganizaDeportes_2.ContainsKey(organizaDeportes) Then
            Dim idOrganizaDeportes As Integer = diccOrganizaDeportes_2(organizaDeportes)
            Me.HddnEmpleadoOrganizaReportesII.Value = idOrganizaDeportes
        Else
            Me.HddnEmpleadoOrganizaReportesII.Value = 0
        End If

    End Sub

    Protected Sub setIdEmpleadoorganizaReportesIII(ByVal sender As Object, ByVal e As EventArgs)

        Dim organizaDeportes As String = Me.txtOrganizaDeportes_3.Text

        If diccOrganizaDeportes_3.ContainsKey(organizaDeportes) Then
            Dim idOrganizaDeportes As Integer = diccOrganizaDeportes_3(organizaDeportes)
            Me.HddnEmpleadoOrganizaReportesIII.Value = idOrganizaDeportes
        Else
            Me.HddnEmpleadoOrganizaReportesIII.Value = 0
        End If

    End Sub


    '<System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()> _
    'Public Shared Function GetAgrupacionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    '    'Dim connectionString As String = ConfigurationManager.ConnectionStrings("CadenaConexion").ConnectionString
    '    'Dim conn As New SqlConnection(connectionString)
    '    '' Try to use parameterized inline query/sp to protect sql injection
    '    'Dim cmd As New SqlCommand((Convert.ToString("SELECT TOP " + count + " idagrupacion, descripcion agrupacion " + " FROM [172.25.107.85].milenium.dbo.agrupaciones " + " WHERE descripcion LIKE '") & prefixText) + "%'", conn)
    '    'Dim oReader As SqlDataReader
    '    'conn.Open()
    '    'Dim CompletionSet As New List(Of String)()
    '    'diccAgrupaciones = New Dictionary(Of String, Integer)()
    '    'oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
    '    'While oReader.Read()
    '    '    CompletionSet.Add(oReader("agrupacion").ToString())
    '    '    diccAgrupaciones.Add(oReader("agrupacion").ToString(), Convert.ToInt32(oReader("idagrupacion").ToString()))
    '    'End While
    '    'conn.Close()
    '    'Return CompletionSet.ToArray()
    'End Function

    <System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()> _
    Public Shared Function GetNombreProspectoJefeList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()

        'If conn.State = ConnectionState.Closed Then
        '    conn.ConnectionString = ("Server=192.168.0.2;Database=Sunshinetix;User=sa;Password=sunshine;")
        'End If

        'Try
        '    conn.Open()
        '    Dim sqlquery As String = "SELECT * FROM Users Where Username = @user;"

        '    Dim data As SqlDataReader
        '    Dim adapter As New SqlDataAdapter
        '    Dim parameter As New SqlParameter
        '    Dim command As SqlCommand = New SqlCommand(sqlquery, conn)
        '    With command.Parameters
        '        .Add(New SqlParameter("@user", password_user.Text))
        '    End With
        '    command.Connection = conn
        '    adapter.SelectCommand = command
        '    data = command.ExecuteReader()
        '    While data.Read
        '        If data.HasRows = True Then
        '            If data(2).ToString = password_user.Text Then
        '                MsgBox("Sucsess")
        '            Else
        '                MsgBox("Login Failed! Please try again or contact support")
        '            End If
        '        Else
        '            MsgBox("Login Failed! Please try again or contact support")
        '        End If
        '    End While
        'Catch ex As Exception

        'End Try


        'Dim conn As New SqlConnection
        'If conn.State = ConnectionState.Closed Then
        '    conn.ConnectionString = ConfigurationManager.ConnectionStrings("CadenaConexion").ConnectionString
        'End If

        'Try
        '    conn.Open()

        '    Dim sqlquery As String = "SELECT TOP " & count & " t1.nombre_completo, t1.idempleado " & _
        '                " FROM ( SELECT t1.Nombre +' '+ t1.ApPaterno +' '+ t1.ApMaterno nombre_completo, t1.idempleado " & _
        '                "           FROM [172.25.107.85].milenium.dbo.usuariosmilenium t1, " & _
        '                "                   [172.25.107.85].milenium.dbo.hoteles t2 " & _
        '                "           WHERE Undone = 'FALSE' " & _
        '                "           AND acronimo = '" + contextKey + "' " & _
        '                "           AND t1.idhotel = t2.idhotel )t1 " & _
        '                " WHERE nombre_completo LIKE '%" & prefixText & "%'"
        '    Dim data As SqlDataReader
        '    Dim adapter As New SqlDataAdapter
        '    'Dim command As New SqlCommand
        '    Dim command As SqlCommand = New SqlCommand(sqlquery, conn)
        '    'command.CommandText = sqlquery
        '    command.Connection = conn
        '    adapter.SelectCommand = command
        '    data = command.ExecuteReader()

        '    While data.Read
        '        'CompletionSet.Add(oReader("nombre_completo").ToString())
        '        'diccProspectoJefe.Add(oReader("nombre_completo").ToString(), oReader("idempleado").ToString())
        '        If data.HasRows = True Then
        '            MsgBox("Login Failed! Please try again or contact support")
        '            'If data(2).ToString = password_user.Text Then
        '            '    MsgBox("Sucsess")
        '            'Else
        '            '    MsgBox("Login Failed! Please try again or contact support")
        '            'End If
        '        Else
        '            MsgBox("Login Failed! Please try again or contact support")
        '        End If
        '    End While

        '    conn.Close()
        '    'Return CompletionSet.ToArray()
        'Catch ex As Exception

        'End Try


        Dim connectionString As String = ConfigurationManager.ConnectionStrings("CadenaConexion").ConnectionString
        Dim conn As New SqlConnection(connectionString)
        ' Try to use parameterized inline query/sp to protect sql injection
        'Dim cmd As New SqlCommand((Convert.ToString((Convert.ToString("SELECT TOP " + count + " t1.nombre_completo, t1.idempleado " + " FROM (" & vbTab & "SELECT" & vbTab & "t1.Nombre +' '+ t1.ApPaterno+' '+t1.ApMaterno nombre_completo, t1.idempleado " + "           FROM" & vbTab & "[172.25.107.85].milenium.dbo.usuariosmilenium t1, " + "                   [172.25.107.85].milenium.dbo.hoteles t2 " + "           WHERE" & vbTab & "Undone = 'FALSE' " + "           AND" & vbTab & vbTab & "acronimo = '") & contextKey) + "' " + "           AND" & vbTab & vbTab & "t1.idhotel = t2.idhotel )t1 " + " WHERE" & vbTab & "nombre_completo LIKE '%") & prefixText) + "%'", conn)
        Dim cmd As New SqlCommand("SELECT TOP " & count & " t1.nombre_completo, t1.idusuario " & _
                        " FROM ( SELECT t1.Nombre +' '+ t1.ApPaterno+' '+t1.ApMaterno nombre_completo, t1.idusuario " & _
                        "           FROM [172.25.107.85].milenium.dbo.usuariosmilenium t1, " & _
                        "                   [172.25.107.85].milenium.dbo.hoteles t2 " & _
                        "           WHERE Undone = 'FALSE' " & _
                        "           AND CASE t2.acronimo WHEN 'CORP' THEN 'CORPORATIVO' ELSE T2.Acronimo END = '" + contextKey + "' " & _
                        "           AND t1.idhotel = t2.idhotel )t1 " & _
                        " WHERE nombre_completo LIKE '%" & prefixText & "%'", conn)

        Dim oReader As SqlDataReader
        conn.Open()
        Dim CompletionSet As New List(Of String)()
        diccProspectoJefe = New Dictionary(Of String, Integer)()
        oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        While oReader.Read()
            CompletionSet.Add(oReader("nombre_completo").ToString())
            diccProspectoJefe.Add(oReader("nombre_completo").ToString(), Convert.ToInt32(oReader("idusuario")))
        End While
        '    CompletionSet.Add(oReader["nombre_completo"].ToString());

        conn.Close()
        Return CompletionSet.ToArray()
    End Function

    '-------------------------
    '----- JEFE PROSPECTO ----
    '-------------------------
    <System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()> _
    Public Shared Function GetNombreProspectoJefeList_ProspectoJefe(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("CadenaConexion").ConnectionString
        Dim conn As New SqlConnection(connectionString)
        ' Try to use parameterized inline query/sp to protect sql injection
        'Dim cmd As New SqlCommand((Convert.ToString((Convert.ToString("SELECT TOP " + count + " t1.nombre_completo, t1.idempleado " + " FROM (" & vbTab & "SELECT" & vbTab & "t1.Nombre +' '+ t1.ApPaterno+' '+t1.ApMaterno nombre_completo, t1.idempleado " + "           FROM" & vbTab & "[172.25.107.85].milenium.dbo.usuariosmilenium t1, " + "                   [172.25.107.85].milenium.dbo.hoteles t2 " + "           WHERE" & vbTab & "Undone = 'FALSE' " + "           AND" & vbTab & vbTab & "acronimo = '") & contextKey) + "' " + "           AND" & vbTab & vbTab & "t1.idhotel = t2.idhotel )t1 " + " WHERE" & vbTab & "nombre_completo LIKE '%") & prefixText) + "%'", conn)
        Dim cmd As New SqlCommand("SELECT TOP " & count & " t1.nombre_completo, t1.idusuario " & _
                        " FROM ( SELECT t1.Nombre +' '+ t1.ApPaterno+' '+t1.ApMaterno nombre_completo, t1.idusuario " & _
                        "           FROM [172.25.107.85].milenium.dbo.usuariosmilenium t1, " & _
                        "                   [172.25.107.85].milenium.dbo.hoteles t2 " & _
                        "           WHERE Undone = 'FALSE' " & _
                        "           AND t1.idhotel = t2.idhotel )t1 " & _
                        " WHERE nombre_completo LIKE '%" & prefixText & "%'", conn)

        Dim oReader As SqlDataReader
        conn.Open()
        Dim CompletionSet As New List(Of String)()
        diccJefeProspecto = New Dictionary(Of String, Integer)()
        oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        While oReader.Read()
            CompletionSet.Add(oReader("nombre_completo").ToString())
            diccJefeProspecto.Add(oReader("nombre_completo").ToString(), Convert.ToInt32(oReader("idusuario")))
        End While
        '    CompletionSet.Add(oReader["nombre_completo"].ToString());

        conn.Close()
        Return CompletionSet.ToArray()
    End Function

    <System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()> _
    Public Shared Function GetNombreProspectoJefeList_ProspectoJefe_2(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("CadenaConexion").ConnectionString
        Dim conn As New SqlConnection(connectionString)
        ' Try to use parameterized inline query/sp to protect sql injection
        'Dim cmd As New SqlCommand((Convert.ToString((Convert.ToString("SELECT TOP " + count + " t1.nombre_completo, t1.idempleado " + " FROM (" & vbTab & "SELECT" & vbTab & "t1.Nombre +' '+ t1.ApPaterno+' '+t1.ApMaterno nombre_completo, t1.idempleado " + "           FROM" & vbTab & "[172.25.107.85].milenium.dbo.usuariosmilenium t1, " + "                   [172.25.107.85].milenium.dbo.hoteles t2 " + "           WHERE" & vbTab & "Undone = 'FALSE' " + "           AND" & vbTab & vbTab & "acronimo = '") & contextKey) + "' " + "           AND" & vbTab & vbTab & "t1.idhotel = t2.idhotel )t1 " + " WHERE" & vbTab & "nombre_completo LIKE '%") & prefixText) + "%'", conn)
        Dim cmd As New SqlCommand("SELECT TOP " & count & " t1.nombre_completo, t1.idusuario " & _
                        " FROM ( SELECT t1.Nombre +' '+ t1.ApPaterno+' '+t1.ApMaterno nombre_completo, t1.idusuario " & _
                        "           FROM [172.25.107.85].milenium.dbo.usuariosmilenium t1, " & _
                        "                   [172.25.107.85].milenium.dbo.hoteles t2 " & _
                        "           WHERE Undone = 'FALSE' " & _
                        "           AND t1.idhotel = t2.idhotel )t1 " & _
                        " WHERE nombre_completo LIKE '%" & prefixText & "%'", conn)

        Dim oReader As SqlDataReader
        conn.Open()
        Dim CompletionSet As New List(Of String)()
        diccJefeProspecto_2 = New Dictionary(Of String, Integer)()
        oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        While oReader.Read()
            CompletionSet.Add(oReader("nombre_completo").ToString())
            diccJefeProspecto_2.Add(oReader("nombre_completo").ToString(), Convert.ToInt32(oReader("idusuario")))
        End While
        '    CompletionSet.Add(oReader["nombre_completo"].ToString());

        conn.Close()
        Return CompletionSet.ToArray()
    End Function

    <System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()> _
    Public Shared Function GetNombreProspectoJefeList_ProspectoJefe_3(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("CadenaConexion").ConnectionString
        Dim conn As New SqlConnection(connectionString)
        ' Try to use parameterized inline query/sp to protect sql injection
        'Dim cmd As New SqlCommand((Convert.ToString((Convert.ToString("SELECT TOP " + count + " t1.nombre_completo, t1.idempleado " + " FROM (" & vbTab & "SELECT" & vbTab & "t1.Nombre +' '+ t1.ApPaterno+' '+t1.ApMaterno nombre_completo, t1.idempleado " + "           FROM" & vbTab & "[172.25.107.85].milenium.dbo.usuariosmilenium t1, " + "                   [172.25.107.85].milenium.dbo.hoteles t2 " + "           WHERE" & vbTab & "Undone = 'FALSE' " + "           AND" & vbTab & vbTab & "acronimo = '") & contextKey) + "' " + "           AND" & vbTab & vbTab & "t1.idhotel = t2.idhotel )t1 " + " WHERE" & vbTab & "nombre_completo LIKE '%") & prefixText) + "%'", conn)
        Dim cmd As New SqlCommand("SELECT TOP " & count & " t1.nombre_completo, t1.idusuario " & _
                        " FROM ( SELECT t1.Nombre +' '+ t1.ApPaterno+' '+t1.ApMaterno nombre_completo, t1.idusuario " & _
                        "           FROM [172.25.107.85].milenium.dbo.usuariosmilenium t1, " & _
                        "                   [172.25.107.85].milenium.dbo.hoteles t2 " & _
                        "           WHERE Undone = 'FALSE' " & _
                        "           AND t1.idhotel = t2.idhotel )t1 " & _
                        " WHERE nombre_completo LIKE '%" & prefixText & "%'", conn)

        Dim oReader As SqlDataReader
        conn.Open()
        Dim CompletionSet As New List(Of String)()
        diccJefeProspecto_3 = New Dictionary(Of String, Integer)()
        oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        While oReader.Read()
            CompletionSet.Add(oReader("nombre_completo").ToString())
            diccJefeProspecto_3.Add(oReader("nombre_completo").ToString(), Convert.ToInt32(oReader("idusuario")))
        End While
        '    CompletionSet.Add(oReader["nombre_completo"].ToString());

        conn.Close()
        Return CompletionSet.ToArray()
    End Function

    '--------------------------
    '---- EJEMPLO A SEGUIR ----
    '--------------------------
    <System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()> _
    Public Shared Function GetNombreProspectoJefeList_EjemploASeguir(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("CadenaConexion").ConnectionString
        Dim conn As New SqlConnection(connectionString)
        ' Try to use parameterized inline query/sp to protect sql injection
        'Dim cmd As New SqlCommand((Convert.ToString((Convert.ToString("SELECT TOP " + count + " t1.nombre_completo, t1.idempleado " + " FROM (" & vbTab & "SELECT" & vbTab & "t1.Nombre +' '+ t1.ApPaterno+' '+t1.ApMaterno nombre_completo, t1.idempleado " + "           FROM" & vbTab & "[172.25.107.85].milenium.dbo.usuariosmilenium t1, " + "                   [172.25.107.85].milenium.dbo.hoteles t2 " + "           WHERE" & vbTab & "Undone = 'FALSE' " + "           AND" & vbTab & vbTab & "acronimo = '") & contextKey) + "' " + "           AND" & vbTab & vbTab & "t1.idhotel = t2.idhotel )t1 " + " WHERE" & vbTab & "nombre_completo LIKE '%") & prefixText) + "%'", conn)
        Dim cmd As New SqlCommand("SELECT TOP " & count & " t1.nombre_completo, t1.idusuario " & _
                        " FROM ( SELECT t1.Nombre +' '+ t1.ApPaterno+' '+t1.ApMaterno nombre_completo, t1.idusuario " & _
                        "           FROM [172.25.107.85].milenium.dbo.usuariosmilenium t1, " & _
                        "                   [172.25.107.85].milenium.dbo.hoteles t2 " & _
                        "           WHERE Undone = 'FALSE' " & _
                        "           AND t1.idhotel = t2.idhotel )t1 " & _
                        " WHERE nombre_completo LIKE '%" & prefixText & "%'", conn)

        Dim oReader As SqlDataReader
        conn.Open()
        Dim CompletionSet As New List(Of String)()
        diccEjemploASeguir = New Dictionary(Of String, Integer)()
        oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        While oReader.Read()
            CompletionSet.Add(oReader("nombre_completo").ToString())
            diccEjemploASeguir.Add(oReader("nombre_completo").ToString(), Convert.ToInt32(oReader("idusuario")))
        End While
        '    CompletionSet.Add(oReader["nombre_completo"].ToString());

        conn.Close()
        Return CompletionSet.ToArray()
    End Function

    <System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()> _
    Public Shared Function GetNombreProspectoJefeList_EjemploASeguir_2(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("CadenaConexion").ConnectionString
        Dim conn As New SqlConnection(connectionString)
        ' Try to use parameterized inline query/sp to protect sql injection
        'Dim cmd As New SqlCommand((Convert.ToString((Convert.ToString("SELECT TOP " + count + " t1.nombre_completo, t1.idempleado " + " FROM (" & vbTab & "SELECT" & vbTab & "t1.Nombre +' '+ t1.ApPaterno+' '+t1.ApMaterno nombre_completo, t1.idempleado " + "           FROM" & vbTab & "[172.25.107.85].milenium.dbo.usuariosmilenium t1, " + "                   [172.25.107.85].milenium.dbo.hoteles t2 " + "           WHERE" & vbTab & "Undone = 'FALSE' " + "           AND" & vbTab & vbTab & "acronimo = '") & contextKey) + "' " + "           AND" & vbTab & vbTab & "t1.idhotel = t2.idhotel )t1 " + " WHERE" & vbTab & "nombre_completo LIKE '%") & prefixText) + "%'", conn)
        Dim cmd As New SqlCommand("SELECT TOP " & count & " t1.nombre_completo, t1.idusuario " & _
                        " FROM ( SELECT t1.Nombre +' '+ t1.ApPaterno+' '+t1.ApMaterno nombre_completo, t1.idusuario " & _
                        "           FROM [172.25.107.85].milenium.dbo.usuariosmilenium t1, " & _
                        "                   [172.25.107.85].milenium.dbo.hoteles t2 " & _
                        "           WHERE Undone = 'FALSE' " & _
                        "           AND t1.idhotel = t2.idhotel )t1 " & _
                        " WHERE nombre_completo LIKE '%" & prefixText & "%'", conn)

        Dim oReader As SqlDataReader
        conn.Open()
        Dim CompletionSet As New List(Of String)()
        diccEjemploASeguir_2 = New Dictionary(Of String, Integer)()
        oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        While oReader.Read()
            CompletionSet.Add(oReader("nombre_completo").ToString())
            diccEjemploASeguir_2.Add(oReader("nombre_completo").ToString(), Convert.ToInt32(oReader("idusuario")))
        End While
        '    CompletionSet.Add(oReader["nombre_completo"].ToString());

        conn.Close()
        Return CompletionSet.ToArray()
    End Function

    <System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()> _
    Public Shared Function GetNombreProspectoJefeList_EjemploASeguir_3(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("CadenaConexion").ConnectionString
        Dim conn As New SqlConnection(connectionString)
        ' Try to use parameterized inline query/sp to protect sql injection
        'Dim cmd As New SqlCommand((Convert.ToString((Convert.ToString("SELECT TOP " + count + " t1.nombre_completo, t1.idempleado " + " FROM (" & vbTab & "SELECT" & vbTab & "t1.Nombre +' '+ t1.ApPaterno+' '+t1.ApMaterno nombre_completo, t1.idempleado " + "           FROM" & vbTab & "[172.25.107.85].milenium.dbo.usuariosmilenium t1, " + "                   [172.25.107.85].milenium.dbo.hoteles t2 " + "           WHERE" & vbTab & "Undone = 'FALSE' " + "           AND" & vbTab & vbTab & "acronimo = '") & contextKey) + "' " + "           AND" & vbTab & vbTab & "t1.idhotel = t2.idhotel )t1 " + " WHERE" & vbTab & "nombre_completo LIKE '%") & prefixText) + "%'", conn)
        Dim cmd As New SqlCommand("SELECT TOP " & count & " t1.nombre_completo, t1.idusuario " & _
                        " FROM ( SELECT t1.Nombre +' '+ t1.ApPaterno+' '+t1.ApMaterno nombre_completo, t1.idusuario " & _
                        "           FROM [172.25.107.85].milenium.dbo.usuariosmilenium t1, " & _
                        "                   [172.25.107.85].milenium.dbo.hoteles t2 " & _
                        "           WHERE Undone = 'FALSE' " & _
                        "           AND t1.idhotel = t2.idhotel )t1 " & _
                        " WHERE nombre_completo LIKE '%" & prefixText & "%'", conn)

        Dim oReader As SqlDataReader
        conn.Open()
        Dim CompletionSet As New List(Of String)()
        diccEjemploASeguir_3 = New Dictionary(Of String, Integer)()
        oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        While oReader.Read()
            CompletionSet.Add(oReader("nombre_completo").ToString())
            diccEjemploASeguir_3.Add(oReader("nombre_completo").ToString(), Convert.ToInt32(oReader("idusuario")))
        End While
        '    CompletionSet.Add(oReader["nombre_completo"].ToString());

        conn.Close()
        Return CompletionSet.ToArray()
    End Function

    '---------------------------
    '---- ORGANIZA DEPORTES ----
    '---------------------------
    <System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()> _
    Public Shared Function GetNombreProspectoJefeList_OrganizaDeportes(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("CadenaConexion").ConnectionString
        Dim conn As New SqlConnection(connectionString)
        ' Try to use parameterized inline query/sp to protect sql injection
        'Dim cmd As New SqlCommand((Convert.ToString((Convert.ToString("SELECT TOP " + count + " t1.nombre_completo, t1.idempleado " + " FROM (" & vbTab & "SELECT" & vbTab & "t1.Nombre +' '+ t1.ApPaterno+' '+t1.ApMaterno nombre_completo, t1.idempleado " + "           FROM" & vbTab & "[172.25.107.85].milenium.dbo.usuariosmilenium t1, " + "                   [172.25.107.85].milenium.dbo.hoteles t2 " + "           WHERE" & vbTab & "Undone = 'FALSE' " + "           AND" & vbTab & vbTab & "acronimo = '") & contextKey) + "' " + "           AND" & vbTab & vbTab & "t1.idhotel = t2.idhotel )t1 " + " WHERE" & vbTab & "nombre_completo LIKE '%") & prefixText) + "%'", conn)
        Dim cmd As New SqlCommand("SELECT TOP " & count & " t1.nombre_completo, t1.idusuario " & _
                        " FROM ( SELECT t1.Nombre +' '+ t1.ApPaterno+' '+t1.ApMaterno nombre_completo, t1.idusuario " & _
                        "           FROM [172.25.107.85].milenium.dbo.usuariosmilenium t1, " & _
                        "                   [172.25.107.85].milenium.dbo.hoteles t2 " & _
                        "           WHERE Undone = 'FALSE' " & _
                        "           AND t1.idhotel = t2.idhotel )t1 " & _
                        " WHERE nombre_completo LIKE '%" & prefixText & "%'", conn)

        Dim oReader As SqlDataReader
        conn.Open()
        Dim CompletionSet As New List(Of String)()
        diccOrganizaDeportes = New Dictionary(Of String, Integer)()
        oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        While oReader.Read()
            CompletionSet.Add(oReader("nombre_completo").ToString())
            diccOrganizaDeportes.Add(oReader("nombre_completo").ToString(), Convert.ToInt32(oReader("idusuario")))
        End While
        '    CompletionSet.Add(oReader["nombre_completo"].ToString());

        conn.Close()
        Return CompletionSet.ToArray()
    End Function

    <System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()> _
    Public Shared Function GetNombreProspectoJefeList_OrganizaDeportes_2(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("CadenaConexion").ConnectionString
        Dim conn As New SqlConnection(connectionString)
        ' Try to use parameterized inline query/sp to protect sql injection
        'Dim cmd As New SqlCommand((Convert.ToString((Convert.ToString("SELECT TOP " + count + " t1.nombre_completo, t1.idempleado " + " FROM (" & vbTab & "SELECT" & vbTab & "t1.Nombre +' '+ t1.ApPaterno+' '+t1.ApMaterno nombre_completo, t1.idempleado " + "           FROM" & vbTab & "[172.25.107.85].milenium.dbo.usuariosmilenium t1, " + "                   [172.25.107.85].milenium.dbo.hoteles t2 " + "           WHERE" & vbTab & "Undone = 'FALSE' " + "           AND" & vbTab & vbTab & "acronimo = '") & contextKey) + "' " + "           AND" & vbTab & vbTab & "t1.idhotel = t2.idhotel )t1 " + " WHERE" & vbTab & "nombre_completo LIKE '%") & prefixText) + "%'", conn)
        Dim cmd As New SqlCommand("SELECT TOP " & count & " t1.nombre_completo, t1.idusuario " & _
                        " FROM ( SELECT t1.Nombre +' '+ t1.ApPaterno+' '+t1.ApMaterno nombre_completo, t1.idusuario " & _
                        "           FROM [172.25.107.85].milenium.dbo.usuariosmilenium t1, " & _
                        "                   [172.25.107.85].milenium.dbo.hoteles t2 " & _
                        "           WHERE Undone = 'FALSE' " & _
                        "           AND t1.idhotel = t2.idhotel )t1 " & _
                        " WHERE nombre_completo LIKE '%" & prefixText & "%'", conn)

        Dim oReader As SqlDataReader
        conn.Open()
        Dim CompletionSet As New List(Of String)()
        diccOrganizaDeportes_2 = New Dictionary(Of String, Integer)()
        oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        While oReader.Read()
            CompletionSet.Add(oReader("nombre_completo").ToString())
            diccOrganizaDeportes_2.Add(oReader("nombre_completo").ToString(), Convert.ToInt32(oReader("idusuario")))
        End While
        '    CompletionSet.Add(oReader["nombre_completo"].ToString());

        conn.Close()
        Return CompletionSet.ToArray()
    End Function

    <System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()> _
    Public Shared Function GetNombreProspectoJefeList_OrganizaDeportes_3(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("CadenaConexion").ConnectionString
        Dim conn As New SqlConnection(connectionString)
        ' Try to use parameterized inline query/sp to protect sql injection
        'Dim cmd As New SqlCommand((Convert.ToString((Convert.ToString("SELECT TOP " + count + " t1.nombre_completo, t1.idempleado " + " FROM (" & vbTab & "SELECT" & vbTab & "t1.Nombre +' '+ t1.ApPaterno+' '+t1.ApMaterno nombre_completo, t1.idempleado " + "           FROM" & vbTab & "[172.25.107.85].milenium.dbo.usuariosmilenium t1, " + "                   [172.25.107.85].milenium.dbo.hoteles t2 " + "           WHERE" & vbTab & "Undone = 'FALSE' " + "           AND" & vbTab & vbTab & "acronimo = '") & contextKey) + "' " + "           AND" & vbTab & vbTab & "t1.idhotel = t2.idhotel )t1 " + " WHERE" & vbTab & "nombre_completo LIKE '%") & prefixText) + "%'", conn)
        Dim cmd As New SqlCommand("SELECT TOP " & count & " t1.nombre_completo, t1.idusuario " & _
                        " FROM ( SELECT t1.Nombre +' '+ t1.ApPaterno+' '+t1.ApMaterno nombre_completo, t1.idusuario " & _
                        "           FROM [172.25.107.85].milenium.dbo.usuariosmilenium t1, " & _
                        "                   [172.25.107.85].milenium.dbo.hoteles t2 " & _
                        "           WHERE Undone = 'FALSE' " & _
                        "           AND t1.idhotel = t2.idhotel )t1 " & _
                        " WHERE nombre_completo LIKE '%" & prefixText & "%'", conn)

        Dim oReader As SqlDataReader
        conn.Open()
        Dim CompletionSet As New List(Of String)()
        diccOrganizaDeportes_3 = New Dictionary(Of String, Integer)()
        oReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        While oReader.Read()
            CompletionSet.Add(oReader("nombre_completo").ToString())
            diccOrganizaDeportes_3.Add(oReader("nombre_completo").ToString(), Convert.ToInt32(oReader("idusuario")))
        End While
        '    CompletionSet.Add(oReader["nombre_completo"].ToString());

        conn.Close()
        Return CompletionSet.ToArray()
    End Function

End Class
