Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Namespace Sistema

    Public Class clImagen
        Public Enum AnchorPosition
            Top
            Center
            Bottom
            Left
            Right
        End Enum
        Public Function ImageResize(ByVal imgPhoto As System.Drawing.Image,
                                        ByVal Width As Integer,
                                        ByVal Height As Integer,
                                        ByVal Anchor As AnchorPosition) As System.Drawing.Image

            Dim sourceWidth As Integer = imgPhoto.Width
            Dim sourceHeight As Integer = imgPhoto.Height
            Dim sourceX As Integer = 0
            Dim sourceY As Integer = 0
            Dim destX As Integer = 0
            Dim destY As Integer = 0

            Dim nPercent As Double = 0
            Dim nPercentW As Double = 0
            Dim nPercentH As Double = 0

            nPercentW = (CDbl(Width) / CDbl(sourceWidth))
            nPercentH = (CDbl(Height) / CDbl(sourceHeight))

            If (nPercentH < nPercentW) Then
                nPercent = nPercentW

                Select Case Anchor
                    Case AnchorPosition.Top
                        destY = 0
                    Case AnchorPosition.Bottom
                        destY = (CInt(Height - (sourceHeight * nPercent)))
                    Case Else
                        destY = (CInt((Height - (sourceHeight * nPercent)) / 2))
                End Select

            Else
                nPercent = nPercentH
                Select Case Anchor
                    Case AnchorPosition.Left
                        destX = 0
                    Case AnchorPosition.Right
                        destX = (CInt(Width - (sourceWidth * nPercent)))
                    Case Else
                        destX = (CInt((Width - (sourceWidth * nPercent)) / 2))
                End Select
            End If

            Dim destWidth As Integer = CInt(sourceWidth * nPercent)
            Dim destHeight As Integer = CInt(sourceHeight * nPercent)

            Dim bmPhoto As Bitmap = New Bitmap(Width, Height, PixelFormat.Format24bppRgb)
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution)

            Dim grPhoto As Graphics = Graphics.FromImage(bmPhoto)
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic

            grPhoto.DrawImage(imgPhoto, New Rectangle(destX, destY, destWidth, destHeight),
            New Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel)

            grPhoto.Dispose()
            Return bmPhoto
        End Function


        Public Function ResizeImage2(ByVal img As System.Drawing.Image,
                                        ByVal Width As Integer,
                                        ByVal Height As Integer) As System.Drawing.Image

            Dim cpy As Bitmap
            If (img.Height < Height And img.Width < Width) Then
                cpy = New Bitmap(Width, Height, PixelFormat.Format32bppArgb)

                Using gr As Graphics = Graphics.FromImage(cpy)
                    gr.Clear(Color.Transparent)

                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic

                    gr.DrawImage(img, New Rectangle(0, 0, Width, Height), New Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel)
                End Using
            Else
                Dim xRatio As Double = CDbl(img.Width) / CDbl(Width)
                Dim yRatio As Double = CDbl(img.Height) / CDbl(Height)
                Dim ratio As Double = Math.Max(xRatio, yRatio)
                Dim nnx As Integer = CInt(Math.Floor(img.Width / ratio))
                Dim nny As Integer = CInt(Math.Floor(img.Height / ratio))
                cpy = New Bitmap(nnx, nny, PixelFormat.Format32bppArgb)

                Using gr As Graphics = Graphics.FromImage(cpy)
                    gr.Clear(Color.Transparent)

                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic

                    gr.DrawImage(img, New Rectangle(0, 0, nnx, nny), New Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel)
                End Using
            End If

            Return cpy
        End Function
    End Class
End Namespace
