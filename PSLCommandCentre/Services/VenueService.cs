using System.Collections.Generic;
using PSLCommandCentre.Domain;
using PSLCommandCentre.Helpers;
using PSLCommandCentre.Repositories;

namespace PSLCommandCentre.Services
{
    public class VenueService
    {
        private readonly VenueRepository _repo = new VenueRepository();

        public List<Venue> GetAllVenues() => _repo.GetAll();

        public bool AddVenue(Venue v)
        {
            var val = Validator.ValidateVenue(v);
            if (!val.IsValid) throw new System.Exception(val.Message);
            return _repo.Add(v);
        }

        public bool UpdateVenue(Venue v)
        {
            var val = Validator.ValidateVenue(v);
            if (!val.IsValid) throw new System.Exception(val.Message);
            return _repo.Update(v);
        }

        public bool DeleteVenue(int id) => _repo.Delete(id);
    }
}