Imports Microsoft.VisualBasic

Imports System.Web.Configuration
Imports System.Data

Public Class DataConn

    Private ConnStr As String
    Private SeccionCnStr As String

    Public Property SeccionConnStr() As String
        Get
            Return SeccionCnStr
        End Get
        Set(ByVal value As String)
            SeccionCnStr = value
            ConnStr = WebConfigurationManager.ConnectionStrings(value).ConnectionString
        End Set
    End Property


    Public Function fncSelCuestionarios(ByVal idhotel as String ) As DataTable
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim Conn As eConnect.DataBase

        Conn = New eConnect.DataBase(ConnStr)
        Conn.TimeOut = 420
        Conn.Open()

        Try
            ds = Conn.GetDataSetBySP("SpSelCuestionariosxHotel", idhotel)
            dt = ds.Tables(0)
        Catch ex As Exception

        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
            Conn.Dispose()
            ds.Dispose()
        End Try

        'Try
        '    Conn = New eConnect.DataBase(ConnStr)
        '    Conn.TimeOut = 420
        '    Conn.Open()
        '    ds = Conn.GetDataSetBySP("SpSelCuestionarios")
        'Catch ex As Exception
        '    Throw ex
        'Finally

        'End Try
        Return dt
    End Function


    Public Function fncSelHoteles() As DataTable
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim Conn As eConnect.DataBase

        Conn = New eConnect.DataBase(ConnStr)
        Conn.TimeOut = 420
        Conn.Open()

        Try
            ds = Conn.GetDataSetBySP("SpSelHotel")
            dt = ds.Tables(0)
        Catch ex As Exception

        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
            Conn.Dispose()
            ds.Dispose()
        End Try

        Return dt
    End Function

    Public Function fncSelPeriodos() As DataTable
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim Conn As eConnect.DataBase

        Conn = New eConnect.DataBase(ConnStr)
        Conn.TimeOut = 420
        Conn.Open()

        Try
            ds = Conn.GetDataSetBySP("SpSelPeriodoEncuesta")
            dt = ds.Tables(0)
        Catch ex As Exception

        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
            Conn.Dispose()
            ds.Dispose()
        End Try

        Return dt
    End Function

    Public Function fncSelJefes(ByVal idhotel As String, ByVal iddepto As Integer) As DataTable
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim Conn As eConnect.DataBase

        Conn = New eConnect.DataBase(ConnStr)
        Conn.TimeOut = 420
        Conn.Open()

        Try
            ds = Conn.GetDataSetBySP("SpSelJefeEncuestas", idhotel, iddepto)
            dt = ds.Tables(0)
        Catch ex As Exception

        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
            Conn.Dispose()
            ds.Dispose()
        End Try

        Return dt
    End Function

    Public Function fncPeriodoEncuesta() As DataTable
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim Conn As eConnect.DataBase

        Conn = New eConnect.DataBase(ConnStr)
        Conn.TimeOut = 420
        Conn.Open()

        Try
            ds = Conn.GetDataSetBySP("SpSelPeriodoEncuesta")
            dt = ds.Tables(0)
        Catch ex As Exception

        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
            Conn.Dispose()
            ds.Dispose()
        End Try

        Return dt
    End Function

    Public Function fncAnioEncuesta() As DataTable
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim Conn As eConnect.DataBase

        Conn = New eConnect.DataBase(ConnStr)
        Conn.TimeOut = 420
        Conn.Open()

        Try
            ds = Conn.GetDataSetBySP("SpSelAnioEncuesta")
            dt = ds.Tables(0)
        Catch ex As Exception

        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
            Conn.Dispose()
            ds.Dispose()
        End Try

        Return dt
    End Function

    Public Function fncTituloEncuesta(ByVal idCuestionario As Integer) As DataTable
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim Conn As eConnect.DataBase

        Conn = New eConnect.DataBase(ConnStr)
        Conn.TimeOut = 420
        Conn.Open()

        Try
            ds = Conn.GetDataSetBySP("SpSelTituloEncuesta", idCuestionario)
            dt = ds.Tables(0)
        Catch ex As Exception

        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
            Conn.Dispose()
            ds.Dispose()
        End Try


        Return dt
    End Function

    Public Function fncPreguntasEncuesta(ByVal idCuestionario As Integer) As DataTable
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim Conn As eConnect.DataBase

        Conn = New eConnect.DataBase(ConnStr)
        Conn.TimeOut = 420
        Conn.Open()

        Try
            ds = Conn.GetDataSetBySP("SpSelConsultaPreguntas", idCuestionario)
            dt = ds.Tables(0)
        Catch ex As Exception

        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
            Conn.Dispose()
            ds.Dispose()
        End Try

        Return dt
    End Function

    Public Function fncPreguntasEncuestaxHotel(ByVal IdHotel As String, ByVal idCuestionario As Integer) As DataTable
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim Conn As eConnect.DataBase

        Conn = New eConnect.DataBase(ConnStr)
        Conn.TimeOut = 420
        Conn.Open()

        Try
            ds = Conn.GetDataSetBySP("SpSelConsultaPreguntas_v2", IdHotel, idCuestionario)
            dt = ds.Tables(0)
        Catch ex As Exception

        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
            Conn.Dispose()
            ds.Dispose()
        End Try

        Return dt
    End Function

    Public Function fncTotalOpXPregunta(ByVal idCuestionario As Integer) As DataTable
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim Conn As eConnect.DataBase

        Conn = New eConnect.DataBase(ConnStr)
        Conn.TimeOut = 420
        Conn.Open()

        Try
            ds = Conn.GetDataSetBySP("SpSelTotalOpXPregunta", idCuestionario)
            dt = ds.Tables(0)
        Catch ex As Exception

        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
            Conn.Dispose()
            ds.Dispose()
        End Try

        Return dt
    End Function


    Public Function fncOpcionesPreguntas(ByVal idPregunta As Integer, ByVal idCuestionario As Integer) As DataTable
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim Conn As eConnect.DataBase

        Conn = New eConnect.DataBase(ConnStr)
        Conn.TimeOut = 420
        Conn.Open()

        Try
            ds = Conn.GetDataSetBySP("SpSelConsultaOpcionPreguntas", idPregunta, idCuestionario)
            dt = ds.Tables(0)
        Catch ex As Exception

        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
            Conn.Dispose()
            ds.Dispose()
        End Try

        Return dt
    End Function

    Public Function fncInsertaEncabezado(ByVal folio As Integer, ByVal idCuestionario As Integer, ByVal idotel As String, ByVal Anio As Integer, ByVal idPeriodo As Integer, ByVal idSexo As Integer, ByVal idUsuario As String) As Integer
        Dim IdRegistro As Integer
        Dim Conn As eConnect.DataBase

        Conn = New eConnect.DataBase(ConnStr)
        Conn.TimeOut = 420
        Conn.Open()

        Try
            'IdRegistro = Conn.ExecuteStoredProc("SpInsEncabezado_v2", folio, idCuestionario, idotel, Anio, idPeriodo, idSexo, idUsuario)
            IdRegistro = Conn.ExecuteStoredProc("SpInsEncabezadoAll", folio, idCuestionario, idotel, Anio, idPeriodo, idSexo, idUsuario)
        Catch ex As Exception

        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
            Conn.Dispose()
        End Try

        Return IdRegistro
    End Function

    Public Function fncInsertaEncabezadoJefesProspecto(ByVal folio As Integer, _
                                                        ByVal idCuestionario As Integer, _
                                                        ByVal idotel As String, ByVal Anio As Integer, _
                                                        ByVal idPeriodo As Integer, _
                                                        ByVal idJefeProspecto As String, _
                                                        ByVal Jefe As String) As Integer
        Dim IdRegistro As Integer
        Dim Conn As eConnect.DataBase

        Conn = New eConnect.DataBase(ConnStr)
        Conn.TimeOut = 420
        Conn.Open()

        Try
            IdRegistro = Conn.ExecuteStoredProc("spInsEncabezado_Prospecto_Jefes", folio, idCuestionario, idotel, Anio, idPeriodo, idJefeProspecto, Jefe)
        Catch ex As Exception

        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
            Conn.Dispose()
        End Try

        Return IdRegistro
    End Function

    Public Function fncInsertaEncabezadoEjemplo_Seguir(ByVal folio As Integer, _
                                                    ByVal idCuestionario As Integer, _
                                                    ByVal idotel As String, ByVal Anio As Integer, _
                                                    ByVal idPeriodo As Integer, _
                                                    ByVal idJefeProspecto As String, _
                                                    ByVal Jefe As String) As Integer
        Dim IdRegistro As Integer
        Dim Conn As eConnect.DataBase

        Conn = New eConnect.DataBase(ConnStr)
        Conn.TimeOut = 420
        Conn.Open()

        Try
            IdRegistro = Conn.ExecuteStoredProc("spInsEncabezado_Ejemplo_Seguir", folio, idCuestionario, idotel, Anio, idPeriodo, idJefeProspecto, Jefe)
        Catch ex As Exception

        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
            Conn.Dispose()
        End Try

        Return IdRegistro
    End Function

    Public Function fncInsertaEncabezadoOrganiza_Deportes_Actividades(ByVal folio As Integer, _
                                                ByVal idCuestionario As Integer, _
                                                ByVal idotel As String, ByVal Anio As Integer, _
                                                ByVal idPeriodo As Integer, _
                                                ByVal idJefeProspecto As String, _
                                                ByVal Jefe As String) As Integer
        Dim IdRegistro As Integer
        Dim Conn As eConnect.DataBase

        Conn = New eConnect.DataBase(ConnStr)
        Conn.TimeOut = 420
        Conn.Open()

        Try
            IdRegistro = Conn.ExecuteStoredProc("spInsEncabezado_Organiza_Deportes_Actividades", folio, idCuestionario, idotel, Anio, idPeriodo, idJefeProspecto, Jefe)
        Catch ex As Exception

        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
            Conn.Dispose()
        End Try

        Return IdRegistro
    End Function

    Public Function FncInsertaRespuesta(ByVal idCuestionario As Integer, _
                                    ByVal idPregunta As Integer, _
                                    ByVal respuesta As String, _
                                    ByVal idEval As Integer, _
                                    ByVal RespuestaOpM As String, _
                                    ByVal Idhotel As String) As Integer
        Dim IdRegistro As Integer
        Dim Conn As eConnect.DataBase

        Conn = New eConnect.DataBase(ConnStr)
        Conn.TimeOut = 420
        Conn.Open()

        Try
            'IdRegistro = Conn.ExecuteStoredProc("SpInsRespuesta_v2", idCuestionario, idPregunta, respuesta, idEval, RespuestaOpM, Idhotel)
            IdRegistro = Conn.ExecuteStoredProc("SpInsRespuestaAll", idCuestionario, idPregunta, respuesta, idEval, RespuestaOpM, Idhotel)
        Catch ex As Exception

        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
            Conn.Dispose()
        End Try

        Return IdRegistro
    End Function

    '-- 22/Sept/2017 --
    'Funcion departamento
    Public Function fncSelDepartamento(ByVal idhotel As String) As DataTable
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim Conn As eConnect.DataBase

        Conn = New eConnect.DataBase(ConnStr)
        Conn.TimeOut = 420
        Conn.Open()

        Try
            ds = Conn.GetDataSetBySP("SpSelDeptosEncuestas", idhotel)
            dt = ds.Tables(0)
        Catch ex As Exception

        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
            Conn.Dispose()
            ds.Dispose()
        End Try

        Return dt
    End Function

End Class
