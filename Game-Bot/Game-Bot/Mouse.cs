using System.Runtime.InteropServices;


namespace MouseControl

{
    //
    /// <summary>
    /// Hexadecimal verileri kullanarak kullanıcının bilgisayarda yapabileceği eylemleri kod ile yapmamızı sağlayan dll dosyalarını kullanan bir sınıf yazdım
    /// İnternetten user32.dll GetAsyncKeyState ya da mouse_event olarak bakarsanız daha çok bilgi bulabilirsiniz
    /// </summary>

    public abstract class Mouse_
    {
        //Değişkene verilen isim ile ilgili olan hexadecimal kodlar
        private const int VK_LBUTTON = 0x01;
        private const int VK_PKEY = 0x50;
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;


        //Herhangi bir tuş basisini belirlemek icin.
        [DllImport("user32.dll")]
        static extern ushort GetAsyncKeyState(int vKey);

        //Mouse ile kullanicinin yapabilecegi eylemleri yaptırmak icin.
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        
        //Mouse sol tıkına basılıp basılamdığını kontrol eder
        public static int Sol_TikaBasildiMi()
        {
            return (GetAsyncKeyState(VK_LBUTTON) & MOUSEEVENTF_ABSOLUTE);
        }
        public static int P_Basildimi()
        {
            return (GetAsyncKeyState(VK_PKEY) & MOUSEEVENTF_ABSOLUTE);
        }

        //Mousun olduğu konuma sol tıklama yapar
        //İstersek konumu kendimizde verebilriz ama orasını çözemedim bende imleci tıklanacak yere ışınlayıp olduğu yere tıklatıyorum
        public static void Sol_Tiklama()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        //Bunları kullanmaya gerek yok şuanlık
        public static void Sag_Tiklama(int x, int y)
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, x, y, 0, 0);
        }
        public static void Orta_Tiklama(int x, int y)
        {
            mouse_event(MOUSEEVENTF_MIDDLEDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_MIDDLEUP, x, y, 0, 0);
        }
    }

}