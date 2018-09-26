using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlideshowDataAccess
{
    public interface IRepository
    {
        // General
        bool SaveAll();

        // Slides
        //IQueryable<Slide> GetAllSlides();
        IEnumerable<Slide> GetAllSlides();

        Slide GetSlide(int slideId);
        
       
        // Slideshow
        IEnumerable<Slideshow> GetAllSlideshows();
        IEnumerable<Slide> GetSlideshowSlides(int slideshowid);
        Slideshow GetSlideshow(int slideshowid);
        Soundtrack GetSoundtrack(int id);
        IEnumerable<Soundtrack> GetAllSoundtracks();
        IEnumerable<User> GetAllUsers();
        User GetUser(int id);

        // Food
        //IQueryable<Food> FindFoodsWithMeasures(string searchString);
        //IQueryable<Food> GetAllFoods();
        //IQueryable<Food> GetAllFoodsWithMeasures();
        //Food GetFood(int id);
        //Measure GetMeasure(int id);

        //// Measure
        //IQueryable<Measure> GetMeasuresForFood(int foodId);

        //// Diary
        //IQueryable<Diary> GetDiaries(string userName);
        //Diary GetDiary(string userName, DateTime day);

        //// DiaryEntry
        //IQueryable<DiaryEntry> GetDiaryEntries(string userName, DateTime diaryDay);
        //DiaryEntry GetDiaryEntry(string userName, DateTime diaryDay, int id);

        //// Users
        //IQueryable<ApiUser> GetApiUsers();

        //// Tokens
        //AuthToken GetAuthToken(string token);

        // Inserts
        //bool Insert(DiaryEntry entry);
        //bool Insert(Diary diary);
        //bool Insert(AuthToken token);

        //// Updates
        //bool Update(DiaryEntry entry);
        //bool Update(Diary diary);

        // Deletes
        //bool DeleteDiaryEntry(int id);
        //bool DeleteDiary(int id);
    }
}
