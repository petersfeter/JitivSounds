﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JitivSounds.Data;
using JitivSounds.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.Web;

namespace JitivSounds.Controllers
{
    [Authorize]
    public class LinksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LinksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Links
        public async Task<IActionResult> Index()
        {
            return View(await _context.Links.Include(x => x.User).Include(x => x.LinkRates).ToListAsync());
        }



        // GET: Links/Create

        public IActionResult Create()
        {
            return PartialView();
        }

        // POST: Links/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Linkyt")] Link link)
        {
            if (await IsLinkInDatabase(link.Linkyt) == true)
            {
                ModelState.AddModelError("Linkyt", "Ten link jest już na liście");
            }

            if (ModelState.IsValid)
            {
                link.DateCreated = DateTime.Now;
                link.UserId = this.User.GetUserId();
                _context.Add(link);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            return View(link);
        }

        private async Task<bool> IsLinkInDatabase(string linkyt)
        {
            var Inbase = await _context.Links.FirstOrDefaultAsync(x => x.Linkyt == linkyt);
            if (Inbase != null)
                return true;
            else return false;
        }



        // GET: Links/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var link = await _context.Links
                .FirstOrDefaultAsync(m => m.Id == id);
            if (link == null)
            {
                return NotFound();
            }

            return PartialView(link);
        }

        // POST: Links/Delete/5        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var link = await _context.Links.FindAsync(id);
            _context.Links.Remove(link);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinkExists(int id)
        {
            return _context.Links.Any(e => e.Id == id);
        }

        public async Task<IActionResult> CountLikes(int linkId, bool like)
        {
            var userId = this.User.GetUserId();
            var result = new Dictionary<string, int>();
            int howManyLikes = 0;
            int howManyDislikes = 0;
            var alreadyClicked = await _context.LinkRates.FirstOrDefaultAsync(x => x.LinkId == linkId && x.UserId == userId);

            var linkrate = new LinkRate
            {
                LinkId = linkId,
                Like = like,
                UserId = userId
            };

            if (alreadyClicked != null)
            {
                _context.LinkRates.Remove(alreadyClicked);
                if (alreadyClicked.Like == false)
                {
                    _context.Add(linkrate);
                }
                await _context.SaveChangesAsync();
                howManyLikes = _context.LinkRates.Count(x => x.LinkId == linkId && x.Like == true);
                howManyDislikes = _context.LinkRates.Count(x => x.LinkId == linkId && x.Like == false);
                result.Add("howManyLikes", howManyLikes);
                result.Add("howManyDislikes", howManyDislikes);
                return Ok(result);
            }

            _context.Add(linkrate);

            await _context.SaveChangesAsync();

            howManyLikes = _context.LinkRates.Count(x => x.LinkId == linkId && x.Like == true);
            howManyDislikes = _context.LinkRates.Count(x => x.LinkId == linkId && x.Like == false);
            result.Add("howManyLikes", howManyLikes);
            result.Add("howManyDislikes", howManyDislikes);

            return Ok(result);
        }


        public async Task<IActionResult> CountDislikes(int linkId, bool like)
        {
            var userId = this.User.GetUserId();
            var result = new Dictionary<string, int>();
            int howManyDislikes = 0;
            int howManyLikes = 0;
            var alreadyClicked = await _context.LinkRates.FirstOrDefaultAsync(x => x.LinkId == linkId && x.UserId == userId);

            var linkrate = new LinkRate()
            {
                LinkId = linkId,
                Like = like,
                UserId = userId
            };

            if (alreadyClicked != null)
            {
                _context.LinkRates.Remove(alreadyClicked);
                if (alreadyClicked.Like == true)
                {
                    _context.Add(linkrate);
                }
                await _context.SaveChangesAsync();
                howManyLikes = _context.LinkRates.Count(x => x.LinkId == linkId && x.Like == true);
                howManyDislikes = _context.LinkRates.Count(x => x.LinkId == linkId && x.Like == false);
                result.Add("howManyLikes", howManyLikes);
                result.Add("howManyDislikes", howManyDislikes);
                return Ok(result);
            }

            _context.Add(linkrate);

            await _context.SaveChangesAsync();

            howManyLikes = _context.LinkRates.Count(x => x.LinkId == linkId && x.Like == true);
            howManyDislikes = _context.LinkRates.Count(x => x.LinkId == linkId && x.Like == false);
            result.Add("howManyLikes", howManyLikes);
            result.Add("howManyDislikes", howManyDislikes);
            return Ok(result);
        }
    }
}
