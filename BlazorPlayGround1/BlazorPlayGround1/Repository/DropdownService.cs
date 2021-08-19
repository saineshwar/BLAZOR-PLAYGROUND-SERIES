using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BlazorPlayGround1.Repository
{
    public class DropdownService: IDropdownService
    {
        private readonly BlazorPlayGroundContext _blazorPlayGroundContext;
        public DropdownService(BlazorPlayGroundContext blazorPlayGroundContext)
        {
            _blazorPlayGroundContext = blazorPlayGroundContext;
        }

        public List<SelectListItem> ListofCountries()
        {
            try
            {
                var listofCountries = (from countries in _blazorPlayGroundContext.Countries.AsNoTracking()
                        select new SelectListItem()
                        {
                            Text = countries.Name,
                            Value = countries.CountryId.ToString()
                        }
                    ).ToList();

                listofCountries.Insert(0, new SelectListItem()
                {
                    Value = "",
                    Text = "---Select---"
                });

                return listofCountries;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SelectListItem> ListofStates(int countryId)
        {
            try
            {
                var listofstates = (from states in _blazorPlayGroundContext.States.AsNoTracking()
                        where states.CountryId == countryId
                        select new SelectListItem()
                        {
                            Text = states.Name,
                            Value = states.StateId.ToString()
                        }
                    ).ToList();
                listofstates.Insert(0, new SelectListItem()
                {
                    Value = "",
                    Text = "---Select---"
                });
                return listofstates;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SelectListItem> ListofCities(int stateid)
        {
            try
            {
                var listofCities = (from cities in _blazorPlayGroundContext.Cities.AsNoTracking()
                        where cities.StateId == stateid
                        select new SelectListItem()
                        {
                            Text = cities.Name,
                            Value = cities.CitiesId.ToString()
                        }
                    ).ToList();

                listofCities.Insert(0, new SelectListItem()
                {
                    Value = "",
                    Text = "---Select---"
                });
                return listofCities;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}