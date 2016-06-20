Imports Microsoft.Practices.EnterpriseLibrary.Data

Namespace Sistema
    Public Class clBD
        Protected db As Database
        Protected Sub New()
            Dim dbFact As DatabaseProviderFactory = New DatabaseProviderFactory()
            db = dbFact.Create("cnnBDSGSST")

            ' db = DatabaseFactory.CreateDatabase
        End Sub
    End Class
End Namespace