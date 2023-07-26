﻿using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Surrogate.Request
{
    public class CampaignRequest:ISurrogate
    {

        public string CampaignCode { get; set; }
        public string CampaignName { get; set; }
        public double CampaignDiscountRate { get; set; }
        public int CampaignStatus { get; set; }
        public DateTime EndDate { get; set; }

    }
}
