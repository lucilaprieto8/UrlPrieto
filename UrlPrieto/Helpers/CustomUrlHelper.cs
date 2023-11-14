namespace UrlPrieto.Helpers
{
    public static class CustomUrlHelper
    {
        public static string Shortener()
        {
            string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            string cadena = "";

            for (int i = 0; i < 6; i++)
            {
                int indice = random.Next(caracteresPermitidos.Length);
                cadena += caracteresPermitidos[indice];
            }
            return cadena;
        }
    }
}

