using Microsoft.AspNetCore.Mvc;
using SortCards.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortCards.Controllers
{
    [ApiController]
    public class SortCardsController : Controller
    {
        private readonly ISortCardsRepository sortCardsRepository;

        public SortCardsController(ISortCardsRepository sortCardsRepository)
        {
            this.sortCardsRepository = sortCardsRepository;
        }
        [HttpPost]
        [Route("SortCardsController")]
        public async Task<IActionResult> GetSortedCardsList([FromBody] List<string> InputList)
        {
            return  Ok(await sortCardsRepository.GetSortedCardsList(InputList));
        }
    }
}
