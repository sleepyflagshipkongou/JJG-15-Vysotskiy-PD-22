namespace lab11
{
    public delegate void ProduceCompletely(patient p);
    public delegate void RenAndex(patient p);


    class Hospital
    {
        public void CompleteProduct(patient p)
        {
            ProduceCompletely MakeAllOp;
            MakeAllOp = MRT;
            MakeAllOp += CT;
            MakeAllOp += Ren;
            MakeAllOp += examinationlor;
            MakeAllOp += Ultrasound;
            MakeAllOp += rheumatictests;
            MakeAllOp.Invoke(p);
        }

        public void RenAndex(patient p)
        {
            RenAndex RenAndexa;
            RenAndexa = Ren;
            RenAndexa += examinationlor;
            RenAndexa.Invoke(p);
        }

        public void DisplayInfo(patient p)
        {
            Console.WriteLine("MRT: {0}", p.MRT);
            Console.WriteLine("CT: {0}", p.CT);
            Console.WriteLine("Ren: {0}", p.Ren);
            Console.WriteLine("examinationlor: {0}", p.examinationlor);
            Console.WriteLine("Ultrasound): {0}", p.Ultrasound);
            Console.WriteLine("rheumatictests: {0}", p.rheumatictests);
        }

        public void MRT(patient p)
        {
            p.MRT = true;
        }
        public void CT(patient p)
        {
            p.CT = true;
        }
        public void Ren(patient p)
        {
            p.Ren = true;
        }
        public void examinationlor(patient p)
        {
            p.examinationlor = true;
        }
        public void Ultrasound(patient p)
        {
            p.Ultrasound = true;
        }
        public void rheumatictests(patient p)
        {
            p.rheumatictests = true;
        }

    }
}