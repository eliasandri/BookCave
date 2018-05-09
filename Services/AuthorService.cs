using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class AuthorService
    {
        private AuthorRepo _authorRepo;

        public AuthorService()
        {
            _authorRepo = new AuthorRepo();
        }

        public List<AuthorListViewModel> GetAllAuthors()
        {
            var authors = _authorRepo.GetAllAuthors();
            return authors;
        }

        public List<AuthorDetailsViewModel> GetAllAuthorsDetails()
        {
            var authors = _authorRepo.GetAllAuthorsDetails();
            return authors;
        }
        public List<AuthorListViewModel> FilterSearch(string orderBy)
        {
        var authors = _authorRepo.FilterSearch(orderBy);
        return authors;
        }
        /*public List<AuthorDetailsViewModel> GetBookByLayoutSearch(string layoutsearch)
        {
        var authors = _authorRepo.GetBookByLayoutSearch(layoutsearch);
        return authors;
        }*/
        public void Delete()
        {
            _authorRepo.Delete();
        }
    }
}