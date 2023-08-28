let menuBtn = document.querySelector("#menu-btn");
let nav = document.querySelector("header nav");
let searchBtn = document.querySelector("#search-btn");
let searchForm = document.querySelector("header #search-form");

menuBtn.onclick = function () {
  menuBtn.classList.toggle("fa-times");
  nav.classList.toggle("active");
  searchBtn.classList.remove("fa-times");
  searchForm.classList.remove("active");
};

searchBtn.onclick = function () {
  searchBtn.classList.toggle("fa-times");
  searchForm.classList.toggle("active");
  menuBtn.classList.remove("fa-times");
  nav.classList.remove("active");
};

window.onscroll = function () {
  searchBtn.classList.remove("fa-times");
  searchForm.classList.remove("active");
  menuBtn.classList.remove("fa-times");
  nav.classList.remove("active");
};

AOS.init({
  duration: 800,
});
