using workerum.entities.enums;

namespace workerum.entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Deparment Deparment { get; set; } // Associando duas classes diferentes através da composição de objetos
        public List<HourContract> Contracts { get; set; } = new List<HourContract>(); //Criando uma lista de contrato para os trabalhadores

        public Worker() { }

        public Worker(string name, WorkerLevel level, double baseSalary, Deparment deparment)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Deparment = deparment;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            foreach (HourContract contract in Contracts) {
                if(contract.Date.Year == year && contract.Date.Month == month){
                    sum += contract.TotalValue();
                }
            }
            return sum;
        }
    }
}
