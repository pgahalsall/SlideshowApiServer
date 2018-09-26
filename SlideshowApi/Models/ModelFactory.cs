using SlideshowDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace SlideshowApi.Models
{
    public class ModelFactory
    {
        private UrlHelper _urlHelper;
        private IRepository _repo;
        public ModelFactory(HttpRequestMessage request, IRepository repo)
        {
            _urlHelper = new UrlHelper(request);
            _repo = repo;
        }

        public SlideModel Create(Slide slide)
        {
            return new SlideModel()
            {
                Id = slide.slide_id,
                Url = _urlHelper.Link("Slide", new { slideid = slide.slide_id }),
                SlideName = slide.slide_name
                //Measures = food.Measures.Select(m => Create(m))
            };
        }

        public UserModel Create(User u)
        {
            return new UserModel()
            {
                Id = u.user_id,
                Url = _urlHelper.Link("User", new { userid = u.user_id }),
                Username = u.username,
                LastUpdated = u.last_updated
            };
        }

        public SlideshowModel Create(Slideshow slideshow)
        {
            SlideshowModel model = new SlideshowModel();
            model.Id = slideshow.slideshow_id;
            model.Url = _urlHelper.Link("slideshow", new { slideshowid = slideshow.slideshow_id });
            model.Description = slideshow.description;
            model.Title = slideshow.slideshow_title;
            model.Producer = slideshow.producer;
            model.LastUpdated = slideshow.last_updated;

            //Slides = slideshow.Slides.Select(s => Create(s))
            return model;
        }

        public SoundtrackModel Create(Soundtrack soundtrack)
        {
            SoundtrackModel model = new SoundtrackModel();
            model.Id = soundtrack.soundtrack_id;
            model.Musician = soundtrack.musician;
            model.Song = soundtrack.song;
            model.Duration = soundtrack.duration;

            return model;
        }

        //internal SlideModel Create(IQueryable<Slide> result)
        //{
        //    throw new NotImplementedException();
        //}

        //public FoodModel Create(Food food)
        //{
        //    return new FoodModel()
        //    {
        //        Url = _urlHelper.Link("Food", new { foodid = food.Id }),
        //        Description = food.Description,
        //        Measures = food.Measures.Select(m => Create(m))
        //    };
        //}

        //public MeasureModel Create(Measure measure)
        //{
        //    return new MeasureModel()
        //    {
        //        Links = new List<LinkModel>()
        //        {
        //          CreateLink(_urlHelper.Link("Measures", new { foodid = measure.Food.Id, id = measure.Id }), "self")
        //        },
        //                    Description = measure.Description,
        //                    Calories = Math.Round(measure.Calories)
        //    };
        //}

        //    public DiaryModel Create(Diary d)
        //    {
        //        return new DiaryModel()
        //        {
        //            Links = new List<LinkModel>()
        //{
        //  CreateLink(_urlHelper.Link("Diaries", new { diaryid = d.CurrentDate.ToString("yyyy-MM-dd") }),
        //    "self"),
        //  CreateLink(_urlHelper.Link("DiaryEntries", new { diaryid = d.CurrentDate.ToString("yyyy-MM-dd") }),
        //    "newDiaryEntry", "POST"),

        //},
        //            CurrentDate = d.CurrentDate,
        //            Entries = d.Entries.Select(e => Create(e))
        //        };
        //    }

        //public LinkModel CreateLink(string href, string rel, string method = "GET", bool isTemplated = false)
        //{
        //    return new LinkModel()
        //    {
        //        Href = href,
        //        Rel = rel,
        //        Method = method,
        //        IsTemplated = isTemplated
        //    };
        //}

        //    public DiaryEntryModel Create(DiaryEntry entry)
        //    {
        //        return new DiaryEntryModel()
        //        {
        //            Links = new List<LinkModel>()
        //{
        //  CreateLink(_urlHelper.Link("DiaryEntries", new { diaryid = entry.Diary.CurrentDate.ToString("yyyy-MM-dd"), id = entry.Id }), "self")
        //},
        //            Quantity = entry.Quantity,
        //            FoodDescription = entry.FoodItem.Description,
        //            MeasureDescription = entry.Measure.Description,
        //            MeasureUrl = _urlHelper.Link("Measures", new { foodid = entry.FoodItem.Id, id = entry.Measure.Id })
        //        };
        //    }

        //public DiaryEntry Parse(DiaryEntryModel model)
        //{
        //    try
        //    {
        //        var entry = new DiaryEntry();

        //        if (model.Quantity != default(double))
        //        {
        //            entry.Quantity = model.Quantity;
        //        }

        //        if (!string.IsNullOrWhiteSpace(model.MeasureUrl))
        //        {
        //            var uri = new Uri(model.MeasureUrl);
        //            var measureId = int.Parse(uri.Segments.Last());
        //            var measure = _repo.GetMeasure(measureId);
        //            entry.Measure = measure;
        //            entry.FoodItem = measure.Food;
        //        }

        //        return entry;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //public Diary Parse(DiaryModel model)
        //{
        //    try
        //    {
        //        var entity = new Diary();

        //        var selfLink = model.Links.Where(l => l.Rel == "self").FirstOrDefault();
        //        if (selfLink != null && !string.IsNullOrWhiteSpace(selfLink.Href))
        //        {
        //            var uri = new Uri(selfLink.Href);
        //            entity.Id = int.Parse(uri.Segments.Last());
        //        }

        //        entity.CurrentDate = model.CurrentDate;

        //        if (model.Entries != null)
        //        {
        //            foreach (var entry in model.Entries) entity.Entries.Add(Parse(entry));
        //        }

        //        return entity;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //public DiarySummaryModel CreateSummary(Diary diary)
        //{
        //    return new DiarySummaryModel()
        //    {
        //        DiaryDate = diary.CurrentDate,
        //        TotalCalories = Math.Round(diary.Entries.Sum(e => e.Measure.Calories * e.Quantity))
        //    };
        //}

        //public AuthTokenModel Create(AuthToken authToken)
        //{
        //    return new AuthTokenModel()
        //    {
        //        Token = authToken.Token,
        //        Expiration = authToken.Expiration
        //    };
        //}

        //    public MeasureV2Model Create2(Measure measure)
        //    {
        //        return new MeasureV2Model()
        //        {
        //            Links = new List<LinkModel>()
        //{
        //  CreateLink(_urlHelper.Link("Measures", new { foodid = measure.Food.Id, id = measure.Id }), "self")
        //},
        //            Description = measure.Description,
        //            Calories = Math.Round(measure.Calories),
        //            Carbohydrates = measure.Carbohydrates,
        //            Cholestrol = measure.Cholestrol,
        //            Fiber = measure.Fiber,
        //            Iron = measure.Iron,
        //            Protein = measure.Protein,
        //            SaturatedFat = measure.SaturatedFat,
        //            Sodium = measure.Sodium,
        //            Sugar = measure.Sugar,
        //            TotalFat = measure.TotalFat
        //        };
        //    }
        //}
    }
}