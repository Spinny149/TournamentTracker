using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        private const string PrizesFile = "PrizeModel.csv";


        //TODO: Make the CreatePrize method actualy save to the tectFile
        public PrizeModel CreatePrize(PrizeModel model)
        {
            //Load the file and convert to List<PrizeModel>
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            //Find the new Id (max +1)
            int currentId = 1;

            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id= currentId;

            //Add new record with new ID
            prizes.Add(model);

            //Save the List<string> to file
            prizes.SaveToPrizeFile(PrizesFile);

            return model;
        }
    }
}
