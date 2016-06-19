Imports Microsoft.Practices.EnterpriseLibrary.Data

Namespace Sistema
    Public Class clBD
        Protected db As Database
        Protected Sub New()
            db = DatabaseFactory.CreateDatabase
        End Sub
    End Class
End Namespace