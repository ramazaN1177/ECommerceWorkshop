using Business.Abstract;
using Core.Utils;
using DataAccess.EF.Abstract;
using DataAccess.EF.Concrete;
using Entities.Entity;
using Entities.Surrogate.Request;
using Entities.Surrogate.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CampaignService : ICampaignService
    {
        private readonly CampaignRepositoryBase _campaignRepository;
        private readonly IProductService _productService;

        public CampaignService(CampaignRepositoryBase campaignRepository,IProductService productService)
        {
            _campaignRepository = campaignRepository;
            _productService = productService;
        }

        public IDataResult<List<CampaignResponse>> GetAll()
        {
           var campaignList = _campaignRepository.GetAll().Select(cp=>new CampaignResponse()
           {
               CampaignId=cp.CampaignId,
               CampaignName=cp.CampaignName,
               CampaignCode=cp.CampaignCode,
               CampaignDiscountRate=cp.CampaignDiscountRate,
               CampaignStatus=cp.CampaignStatus,
               CreateDate=cp.CreateDate,
               EditDate=cp.EditDate,
               EndDate=cp.EndDate,
               StartDate=cp.StartDate

           }).ToList();

            return new SuccessDataResult<List<CampaignResponse>>(campaignList,  "Kampanya bilgileri getirildi.");
                
        }

        public IDataResult<CampaignResponse> Get(int id)
        {
            var campaign = _campaignRepository.Get(cp => cp.CampaignId == id);
            var campaignResponse = new CampaignResponse()
            {
                CampaignId = campaign.CampaignId,
                CampaignName = campaign.CampaignName,
                CampaignCode = campaign.CampaignCode,
                CampaignDiscountRate = campaign.CampaignDiscountRate,
                CampaignStatus = campaign.CampaignStatus,
                CreateDate = campaign.CreateDate,
                EditDate = campaign.EditDate,
                EndDate = campaign.EndDate,
                StartDate = campaign.StartDate
            };
            return new SuccessDataResult<CampaignResponse>(campaignResponse, "Kampanya biilgisi getirildi");
        }

        public IResult Add(CampaignRequest data)
        {
            var entity = new Campaign()
            {
             
                CampaignName = data.CampaignName,
                CampaignCode = data.CampaignCode,
                CampaignDiscountRate = data.CampaignDiscountRate,
                CampaignStatus = data.CampaignStatus,
                CreateDate =DateTime.Now,
                EditDate =  DateTime.Now,
                EndDate =data.EndDate,
                StartDate = DateTime.Now,
            };
            _campaignRepository.Add(entity);
            return new SuccessResult("Kampanya kaydedildi.");
        }

        public IResult Update(int id, CampaignRequest data)
        {
            var campaign = _campaignRepository.Get(cp => cp.CampaignId == id);
            campaign.CampaignName = data.CampaignName;
            campaign.CampaignCode = data.CampaignCode;
            campaign.CampaignDiscountRate = data.CampaignDiscountRate;
            campaign.CampaignStatus = data.CampaignStatus;
                 campaign.CreateDate = DateTime.Now;
                 campaign.EditDate = DateTime.Now;
                 campaign.EndDate = data.EndDate;
                 campaign.StartDate = DateTime.Now;
            return new SuccessResult("Kategori başarıyla güncellendi");
        }

        public IResult Delete(int id)
        {
            var campaign = _campaignRepository.Get(cp => cp.CampaignId == id);
            _campaignRepository.Delete(campaign);
            return new SuccessResult("Kampanya başarıyla silindi.");
        }






    }
}
