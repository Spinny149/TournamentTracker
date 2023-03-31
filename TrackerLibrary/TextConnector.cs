using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class TextConnector : IDataConnection
    {
        //TODO: Make the CreatePrize method actualy save to the tectFile
        public PrizeModel CreatePrize(PrizeModel model)
        {
            model.Id = 1;

            return model;
        }
    }
}
