using FirstApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 
    Methods :
        - Void method without parameter
        - Void method with parameter
        - Return method without parameter
        - Return method with parameter
*/

namespace FirstApp
{
    // Contract / SOP / Standard
    interface IMouse
    {
        void LeftClick();
        void RightClick();
        void MiddleClick();
    }

    abstract class AbstractMouse
    {
        public virtual void LeftClick() { }
        public abstract void RightClick();
        public abstract void MiddleClick();
    }

    class Contoh : AbstractMouse
    {
        public override void MiddleClick()
        {
            throw new NotImplementedException();
        }

        public override void RightClick()
        {
            throw new NotImplementedException();
        }
    }

    interface IPhone
    {
        void Call(string number);
        void Reject();
        void Accept();
    }

    class Phillips : IPhone
    {
        private bool inCall = false;

        public void Accept()
        {
            inCall = true;
        }

        public void Call(string number)
        {
            inCall = true;
        }

        public void Reject()
        {
            
        }

        public void Reboot() { }
    }

    class Panasonic : IPhone
    {
        private bool inCall = false;
        private string number;

        public void Accept()
        {
            inCall = true;
        }

        public void Call(string number)
        {
            inCall = true;
            this.number = number;
        }

        public void Reject()
        {

        }
    }

    class Mouse : IMouse
    {
        private bool leftButton = false;
        private bool rightButton = false;
        private bool middleButton = false;

        public void LeftClick()
        {
            leftButton = true;
            process(new int[] { 4, 1 });
        }

        public void RightClick()
        {
            rightButton = true;
            process(new int[] { 4});
        }

        public void MiddleClick()
        {
            middleButton = true;
            process(null);
        }

        private void process(int[] coordinate)
        {
            Console.WriteLine("Clicking on coordinate {0},{1}", coordinate[0], coordinate[1]);
        }
    }

    class MouseGaming : Mouse
    {
        // 400 800 1600 3200
        private int dpi;

        public MouseGaming()
        {
            dpi = 400;
        }

        public void DPIClick()
        {
            dpi += 400;
            Console.WriteLine(dpi);
        }

        public void ForwardClick() { }
        public void BackwardClick() { }
    }
    
    class MouseRGB : Mouse
    {
        private int blinkSpeed;

        public MouseRGB()
        {
            blinkSpeed = 500;
        }

        public void RGBClick()
        {
            blinkSpeed += 500;
        }
    }



    interface ISenjata
    {
        void Shoot();
        void Reload();
    }

    class Magazine
    {
        private int bulletCapacity;
        public int BulletCapacity
        {
            get { return bulletCapacity; }
            set { bulletCapacity = value; }
        }
    }

    class SingleMag : Magazine
    {
        public SingleMag()
        {
            BulletCapacity = 40;
        }
    }

    class DoubleMag : Magazine
    {
        public DoubleMag()
        {
            BulletCapacity = 80;
        }
    }

    class Sight
    {
        private int zoom;
    }

    class DotSight : Sight
    {

    }

    class RedDot : Sight
    {

    }

    class AK47 : ISenjata
    {
        private Magazine magazine;
        private Sight sight;
        private int mode;

        public AK47()
        {
            magazine = new SingleMag();
            mode = 0;
        }

        public void Reload()
        {
            magazine.BulletCapacity = 40;
        }

        public void Shoot()
        {
            magazine.BulletCapacity--;
        }

        public void SetSight(Sight sight)
        {
            this.sight = sight;
        }
    }

    // Add, View, Delete
    // OOP
    // Try Catch

    class SistemPegawai {
        // Array / List
        private List<Dictionary<string, string>> listPegawai;

        public SistemPegawai()
        {
            listPegawai = new List<Dictionary<string, string>>();
        }

        public void Add(Dictionary<string, string> pegawai)
        {
            listPegawai.Add(pegawai);
        }

        public void Add(string nama, string nip, string jabatan)
        {
            Dictionary<string, string> pegawai = new Dictionary<string, string>() {
                ["nip"] = nip,
                ["nama"] = nama,
                ["jabatan"] = jabatan
            };
            listPegawai.Add(pegawai);
        }

        public void View()
        {
            Console.WriteLine("NIP\tNama\tJabatan");
            foreach(var pegawai in listPegawai)
            {
                Console.Write("{0}\t{1}\t{2}\n", pegawai["nip"], pegawai["nama"], pegawai["jabatan"]);
            }
        }

        public void Delete(int index)
        {
            try
            {
                listPegawai.RemoveAt(index);
            }catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Data Tidak Ada");
            }
        }
    }









    class Program
    {
        static void Main(string[] args)
        {
            Query query = new Query();
            var employee = query.GetOne(101);

            Console.WriteLine("{0} {1} {2}", employee["employee_id"], employee["first_name"], employee["last_name"]);

            //foreach(var employee in employees)
            //{
            //    Console.WriteLine("{0} {1} {2}", employee["employee_id"], employee["first_name"], employee["last_name"]);
            //}

            Console.ReadKey();
        }
    }
}
