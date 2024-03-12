using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_IDE_CPP.Utils
{
    public class MinGW
    {

        public void Install()
        {
            InitMinGW();
        } 

        private void InitMinGW()
        {
            // Especifique o caminho completo do arquivo .bat
            string caminhoBat = @"initMingw.bat";

            // Verifique se o arquivo .bat existe
            if (System.IO.File.Exists(caminhoBat))
            {
                if (Directory.Exists("MinGW")) return;
                // Configurar o processo para executar o arquivo .bat
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = caminhoBat,
                    UseShellExecute = true,
                    CreateNoWindow = true // Defina como true para ocultar a janela do console
                };

                try
                {
                    // Iniciar o processo
                    using (Process processo = new Process { StartInfo = psi })
                    {
                        processo.Start();
                        processo.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
    }

    
}
