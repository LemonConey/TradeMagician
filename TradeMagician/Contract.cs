using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeMagician
{
    public class Contract
    {
        public String ContractName { get; set; }
        public String ContractID { get; set; }

        public Contract(String contractId, String contractName)
        {
            this.ContractID = contractId;
            this.ContractName = contractName;
        }

        public static IList<Contract> GetCurrentContract()
        {
            IList<Contract> contracts = new List<Contract>();
            DateTime now = DateTime.Now;
            String pre = "IF";
            String year = now.Year.ToString().Substring(2, 2);
            for (Int32 month = 1; month <= 12; month++)
            {
                String contractId = String.Format("IF{0}{1:00}",year,month);
                Contract contract = new Contract(contractId, contractId);
                contracts.Add(contract);
            }
            //TODO: for test
            contracts.Add(new Contract("IF1210", "IF1210"));
            contracts.Add(new Contract("IF1211", "IF1211"));
            contracts.Add(new Contract("IF1212", "IF1212"));
            
            return contracts;
        }

        public static String GetSubscribeString(IList<Contract> contracts)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Contract contract in contracts)
            {
                sb.Append(contract.ContractName);
                sb.Append(";");
            }
            return sb.ToString();
        }
    }
}
