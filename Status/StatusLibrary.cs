using Facebook;
using System;
using System.Dynamic;
using System.IO;
using Google.Apis.Urlshortener.v1;
using Google.Apis.Services;
using System.Drawing;
using System.Net;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Linq;

namespace Status
{
    public class StatusLibrary
    {
        private const string FacebookApiId = "1826800460927997";
        private const string FacebookApiSecret = "93ba223d38d5484a6dfd730e1e0cd131";
        static string pageAccessToken = "EAAZA9dyCMkZC0BANUiZCQqgJ35rfc7Fg5hyYEIFa35pqZCxnJnNKeRLwaCTioPaZCuFaqzzufV1uhNjahZAVNf9K7MD5i5sirJ43vJQ6ohHZAyQ9YlZCKS9vWCXn4gMZB22GNXqHXH9B8KaC3TYZAfJqzBjXq1rZAIT5gsaRletqty2aAZDZD";
        bool tamnaSlika = true;

        public bool PostaviStatus(string tekst, string urlSlike, string urlPonude)
        {
            string skraceniUrl = SkratiUrl(urlPonude);
            MemoryStream spojenaSlika = SpojiSlike(urlSlike);

            string popravljeniTekst = tekst + "\r\n\r\n Više na ---> " + skraceniUrl;

            try
            {
                FacebookClient facebookClient = new FacebookClient(pageAccessToken);

                dynamic parameters = new ExpandoObject();
                parameters.message = popravljeniTekst;
                parameters.access_token = pageAccessToken;
                parameters.source = new FacebookMediaObject
                {
                    ContentType = "image/png",
                    FileName = "dajsvePonuda.png"
                }.SetValue(spojenaSlika.ToArray());

                var rezultat = facebookClient.Post("/148694365186827/photos", parameters);
                
                return true;
            }
            catch (FacebookOAuthException ex)
            {
                return false;
            }
            catch (FacebookApiException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string SkratiUrl(string urlPonude)
        {
            ServiceReference1.UrlShorteningServiceSoapClient cli = new ServiceReference1.UrlShorteningServiceSoapClient();
            string s = cli.ShortenUrl(urlPonude, "shorteningNekatamoSifra4432");

            return s;
        }

        public MemoryStream SpojiSlike(string urlSlikePonude)
        {
            Image logoBijeli = Image.FromFile(@"H:\\Users\\Filip\\Desktop\\dajsve\\dajsvebijeli.png", true);
            Image logoLjubicasti = Image.FromFile(@"H:\\Users\\Filip\\Desktop\\dajsve\\dajsveljubicasti.png", true);

            MemoryStream slikaPonudeMemoryStream = new MemoryStream();
            MemoryStream spojenaSlikaMemoryStream = new MemoryStream();
            Image slikaPonude = null;


            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] data = webClient.DownloadData(urlSlikePonude);

                    using (MemoryStream mem = new MemoryStream(data))
                    {
                        slikaPonude = Image.FromStream(mem);
                    }
                }


                string mjestoPostavljanjaLoga = OdrediMjestoPostavljanjaLoga(slikaPonude);

                if (slikaPonude == null)
                {
                    throw new ArgumentNullException("Slika ponude nije dostupna");
                }

                Bitmap slika = new Bitmap(slikaPonude.Width, slikaPonude.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                switch (mjestoPostavljanjaLoga)
                {
                    case "LG":
                        using (Graphics graphics = Graphics.FromImage(slika))
                        {
                            graphics.DrawImage(slikaPonude, new Rectangle(new Point(), slikaPonude.Size),
                                new Rectangle(new Point(), slikaPonude.Size), GraphicsUnit.Pixel);
                            if (tamnaSlika == false) graphics.DrawImage(logoLjubicasti, new Rectangle(new Point(0, 4), logoLjubicasti.Size),
                                 new Rectangle(new Point(), logoLjubicasti.Size), GraphicsUnit.Pixel);
                            else graphics.DrawImage(logoBijeli, new Rectangle(new Point(0, 0), logoBijeli.Size),
                                new Rectangle(new Point(), logoBijeli.Size), GraphicsUnit.Pixel);
                        };
                        break;
                    case "DG":
                        using (Graphics graphics = Graphics.FromImage(slika))
                        {
                            graphics.DrawImage(slikaPonude, new Rectangle(new Point(), slikaPonude.Size),
                                new Rectangle(new Point(), slikaPonude.Size), GraphicsUnit.Pixel);
                            if (tamnaSlika == false) graphics.DrawImage(logoLjubicasti, new Rectangle(new Point(slikaPonude.Width - logoLjubicasti.Width, 0), logoLjubicasti.Size),
                                 new Rectangle(new Point(), logoLjubicasti.Size), GraphicsUnit.Pixel);
                            else graphics.DrawImage(logoBijeli, new Rectangle(new Point(slikaPonude.Width - logoBijeli.Width, 4), logoBijeli.Size),
                                new Rectangle(new Point(), logoBijeli.Size), GraphicsUnit.Pixel);
                        };
                        break;
                    case "LD":
                        using (Graphics graphics = Graphics.FromImage(slika))
                        {
                            graphics.DrawImage(slikaPonude, new Rectangle(new Point(), slikaPonude.Size),
                                new Rectangle(new Point(), slikaPonude.Size), GraphicsUnit.Pixel);
                            if (tamnaSlika == false) graphics.DrawImage(logoLjubicasti, new Rectangle(new Point(0, slikaPonude.Height - logoLjubicasti.Height), logoLjubicasti.Size),
                                new Rectangle(new Point(), logoLjubicasti.Size), GraphicsUnit.Pixel);
                            else graphics.DrawImage(logoBijeli, new Rectangle(new Point(0, slikaPonude.Height - logoBijeli.Height), logoBijeli.Size),
                                new Rectangle(new Point(), logoBijeli.Size), GraphicsUnit.Pixel);
                        };
                        break;
                    case "DD":
                        using (Graphics graphics = Graphics.FromImage(slika))
                        {
                            graphics.DrawImage(slikaPonude, new Rectangle(new Point(), slikaPonude.Size),
                                new Rectangle(new Point(), slikaPonude.Size), GraphicsUnit.Pixel);
                            if (tamnaSlika == false) graphics.DrawImage(logoLjubicasti, new Rectangle(new Point(slikaPonude.Width - logoLjubicasti.Width, slikaPonude.Height - logoLjubicasti.Height), logoLjubicasti.Size),
                                new Rectangle(new Point(), logoLjubicasti.Size), GraphicsUnit.Pixel);
                            else graphics.DrawImage(logoBijeli, new Rectangle(new Point(slikaPonude.Width - logoBijeli.Width, slikaPonude.Height - logoBijeli.Height), logoBijeli.Size),
                                new Rectangle(new Point(), logoBijeli.Size), GraphicsUnit.Pixel);
                        };
                        break;
                    default:
                        using (Graphics graphics = Graphics.FromImage(slika))
                        {
                            graphics.DrawImage(slikaPonude, new Rectangle(new Point(), slikaPonude.Size),
                                new Rectangle(new Point(), slikaPonude.Size), GraphicsUnit.Pixel);
                            if (tamnaSlika == false) graphics.DrawImage(logoLjubicasti, new Rectangle(new Point(0, 0), logoLjubicasti.Size),
                                new Rectangle(new Point(), logoLjubicasti.Size), GraphicsUnit.Pixel);
                            else graphics.DrawImage(logoBijeli, new Rectangle(new Point(0, 0), logoBijeli.Size),
                               new Rectangle(new Point(), logoBijeli.Size), GraphicsUnit.Pixel);
                        };
                        break;
                }

                slika.Save(spojenaSlikaMemoryStream, ImageFormat.Png);
            }
            catch(Exception ex)
            {
                return null;
            }

            return spojenaSlikaMemoryStream;
        }

        public string OdrediMjestoPostavljanjaLoga(Image slikaPonude)
        {
            var LGBoje = new List<Color>();
            var DGBoje = new List<Color>();
            var LDBoje = new List<Color>();
            var DDBoje = new List<Color>();
            Image logoBijeli = Image.FromFile(@"H:\\Users\\Filip\\Desktop\\dajsve\\dajsvebijeli.png", true);
            Image logoLjubicasti = Image.FromFile(@"H:\\Users\\Filip\\Desktop\\dajsve\\dajsveljubicasti.png", true);
            Rectangle section = new Rectangle(new Point(0, 0), logoLjubicasti.Size);
            Bitmap bmp = new Bitmap(section.Width, section.Height);

            Bitmap bmpImage = new Bitmap(slikaPonude);
            List<Bitmap> listaBitmap = new List<Bitmap>();
            Bitmap LGKut, DGKut, LDKut, DDKut;

            if (tamnaSlika) {
                LGKut = bmpImage.Clone(new System.Drawing.Rectangle(0, 0, logoLjubicasti.Width, logoLjubicasti.Height), bmpImage.PixelFormat);
                DGKut = bmpImage.Clone(new System.Drawing.Rectangle(slikaPonude.Width - logoLjubicasti.Width, 0, logoLjubicasti.Width, logoLjubicasti.Height), bmpImage.PixelFormat);
                LDKut = bmpImage.Clone(new System.Drawing.Rectangle(0, slikaPonude.Height - logoLjubicasti.Height, logoLjubicasti.Width, logoLjubicasti.Height), bmpImage.PixelFormat);
                DDKut = bmpImage.Clone(new System.Drawing.Rectangle(slikaPonude.Width - logoLjubicasti.Width, slikaPonude.Height - logoLjubicasti.Height, logoLjubicasti.Width, logoLjubicasti.Height), bmpImage.PixelFormat);
            }
            else {
                LGKut = bmpImage.Clone(new System.Drawing.Rectangle(0, 0, logoBijeli.Width, logoBijeli.Height), bmpImage.PixelFormat);
                DGKut = bmpImage.Clone(new System.Drawing.Rectangle(slikaPonude.Width - logoBijeli.Width, 0, logoBijeli.Width, logoBijeli.Height), bmpImage.PixelFormat);
                LDKut = bmpImage.Clone(new System.Drawing.Rectangle(0, slikaPonude.Height - logoBijeli.Height, logoBijeli.Width, logoBijeli.Height), bmpImage.PixelFormat);
                DDKut = bmpImage.Clone(new System.Drawing.Rectangle(slikaPonude.Width - logoBijeli.Width, slikaPonude.Height - logoBijeli.Height, logoBijeli.Width, logoBijeli.Height), bmpImage.PixelFormat);
            };

            for (int x = 0; x < LGKut.Size.Width; x++)
            {
                for (int y = 0; y < LGKut.Size.Height; y++)
                {
                    LGBoje.Add(LGKut.GetPixel(x, y));
                }
            }

            for (int x = 0; x < DGKut.Size.Width; x++)
            {
                for (int y = 0; y < DGKut.Size.Height; y++)
                {
                    DGBoje.Add(DGKut.GetPixel(x, y));
                }
            }

            for (int x = 0; x < LDKut.Size.Width; x++)
            {
                for (int y = 0; y < LDKut.Size.Height; y++)
                {
                    LDBoje.Add(LDKut.GetPixel(x, y));
                }
            }

            for (int x = 0; x < DDKut.Size.Width; x++)
            {
                for (int y = 0; y < DDKut.Size.Height; y++)
                {
                    DDBoje.Add(DDKut.GetPixel(x, y));
                }
            }

            float LGKutSvjetlina = LGBoje.Average(boja => boja.GetBrightness());
            float DGKutSvjetlina = DGBoje.Average(boja => boja.GetBrightness());
            float LDKutSvjetlina = LDBoje.Average(boja => boja.GetBrightness());
            float DDKutSvjetlina = DDBoje.Average(boja => boja.GetBrightness());
            List<float> listaSvjetlina = new List<float>();
            float najmanjaSvjetlost = 0;

            listaSvjetlina.Add(LGKutSvjetlina);
            listaSvjetlina.Add(DGKutSvjetlina);
            listaSvjetlina.Add(LDKutSvjetlina);
            listaSvjetlina.Add(DDKutSvjetlina);

            float najmanjaSvjetlina = listaSvjetlina.Min();
            float najvecaSvjetlina = listaSvjetlina.Max();
            float odabranaSvjetlina = 0;

            if ((1 - najvecaSvjetlina) > (najmanjaSvjetlina))
            {
                odabranaSvjetlina = najmanjaSvjetlina;
            }
            else if ((1 - najvecaSvjetlina) <= (najmanjaSvjetlina))
            {
                odabranaSvjetlina = najvecaSvjetlina;
            }

            if (odabranaSvjetlina >= 0.5)
                tamnaSlika = false;
            else
                tamnaSlika = true;

            if (odabranaSvjetlina == LGKutSvjetlina) return "LG";
            else if (odabranaSvjetlina == DGKutSvjetlina) return "DG";
            else if (odabranaSvjetlina == LDKutSvjetlina) return "LD";
            else if (odabranaSvjetlina == DDKutSvjetlina) return "DD";
            else return "LG";
        }
    }
}   
