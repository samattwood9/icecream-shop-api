using api.Domains.Interfaces;
using api.DTOs;
using api.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;


namespace api.Domains
{
    public class Sample : ISample
    {
        private readonly string domain;

        private readonly Context context;

        private readonly ILogger logger;

        public Sample(Context _context, ILogger<Sample> _logger)
        {
            context = _context;

            logger = _logger;
        }

        public IConfiguration Configuration { get; }

        public List<SampleDTO> ReadItems()
        {
            List<SampleDTO> samples = new List<SampleDTO>();
            foreach (Models.Sample sample in context.Samples)
            {
                samples.Add(new SampleDTO
                {
                    Id = sample.Id,
                    CreatedAt = sample.CreatedAt,
                    TestBool = sample.TestBool,
                    SecondTestBool = sample.SecondTestBool,
                    FavouriteNumber = sample.FavouriteNumber
                });
            }
            return samples;
        }

        public SampleDTO ReadItem(string id)
        {
            Models.Sample sample = context.Samples.Where(s=> s.Id == id).FirstOrDefault();

            return new SampleDTO
            {
                Id = sample.Id,
                CreatedAt = sample.CreatedAt,
                TestBool = sample.TestBool,
                SecondTestBool = sample.SecondTestBool,
                FavouriteNumber = sample.FavouriteNumber
            };
        }

        public SampleDTO EditItem(SampleDTO item)
        {
            Models.Sample sample = context.Samples.Where(s=> s.Id == item.Id).FirstOrDefault();

            item.Id = sample.Id;
            item.CreatedAt = sample.CreatedAt;
            item.TestBool = sample.TestBool;
            item.SecondTestBool = sample.SecondTestBool;
            item.FavouriteNumber = sample.FavouriteNumber;
            
            context.SaveChanges();

            return new SampleDTO
            {
                Id = sample.Id,
                CreatedAt = sample.CreatedAt,
                TestBool = sample.TestBool,
                SecondTestBool = sample.SecondTestBool,
                FavouriteNumber = sample.FavouriteNumber
            };

        }

        public SampleDTO AddItem(SampleDTO item)
        {
            context.Samples.Add(new Models.Sample{
                Id = item.Id,
                CreatedAt = item.CreatedAt,
                TestBool = item.TestBool,
                SecondTestBool = item.SecondTestBool,
                FavouriteNumber = item.FavouriteNumber
            });

            context.SaveChanges();

            return new SampleDTO
            {
                Id = item.Id,
                CreatedAt = item.CreatedAt,
                TestBool = item.TestBool,
                SecondTestBool = item.SecondTestBool,
                FavouriteNumber = item.FavouriteNumber
            };
        }

        public void DeleteItem(string id)
        {

            Models.Sample sample = context.Samples.Where(s => s.Id == id).FirstOrDefault();
            context.Samples.Remove(sample);
            context.SaveChanges();
        } 

    }

}
