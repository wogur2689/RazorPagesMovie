using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

/**
 * RazorPages는 PageModel에서 파생됨.
 * PageModel 파생 클래스의 이름은 PageNameModel로 지정.
 * 생성자는 종속성 주입을 사용해서 RazorPageMovieContext를 페이지에 추가
 */
namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        /**
         * 페이지에 대한 GET 요청을 만들면  OnGetAsync 메서드가 RazorPage에
         * 동영상 목록을 반환함.
         * 
         * Razor페이지에서 OnGetAsync 또는 OnGet을 호출하여 페이지 상태를 초기화
         * 그 후 OnGetAsync는 동영상 목록을 가져와 표시
         * 
         * OnGet이 void를 반환하거나 OnGetAsync가 Task를 반환하면
         * return문이 사용되지 않은것임.
         */
        public async Task OnGetAsync()
        {
            if (_context.Movie != null)
            {
                Movie = await _context.Movie.ToListAsync();
            }
        }
    }
}
