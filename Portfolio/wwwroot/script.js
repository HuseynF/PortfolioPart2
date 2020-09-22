$(document).ready(function () {
  $(".burgermenu").click(function () {
    $(".burgeritems").slideToggle()
  })
  $("a").on('click', function (event) {
    if (this.hash !== "") {
      event.preventDefault();
      var hash = this.hash;
      $('html, body').animate({
        scrollTop: $(hash).offset().top
      }, 800, function () {
        window.location.hash = hash;
      });
    }
  });
})

///MODAL
var modal = document.querySelector("#modalcommerce");

var btn = document.querySelector("#commerce");

var span = document.querySelector("#closecommerce");

var modal1 = document.querySelector("#modalflower");

var btn1 = document.querySelector("#flower");

var span1 = document.querySelector("#closeflower");

var modal2 = document.querySelector("#modalwindows");

var btn2 = document.querySelector("#windows");

var span2 = document.querySelector("#closewindows");

var modal3 = document.querySelector("#modalmeme");

var btn3 = document.querySelector("#meme");

var span3 = document.querySelector("#closememe");


btn.onclick = function () {
    modal.style.display = "block";
}
span.onclick = function () {
    modal.style.display = "none";
}
window.onclick = function (event) {
    if (event.target == modal || event.target == modal1 || event.target == modal2 || event.target == modal3) {
        modal.style.display = "none";
        modal1.style.display = "none";
        modal2.style.display = "none";
        modal3.style.display = "none";
    }
}

btn1.onclick = function () {
    modal1.style.display = "block";
}
span1.onclick = function () {
    modal1.style.display = "none";
}
btn2.onclick = function () {
    modal2.style.display = "block";
}
span2.onclick = function () {
    modal2.style.display = "none";
}
btn3.onclick = function () {
    modal3.style.display = "block";
}
span3.onclick = function () {
    modal3.style.display = "none";
}

///BACK TO TOP
const backtotop = document.getElementById('backtotop')

window.onscroll = function () { scrollfunction() }

function scrollfunction() {
  if (document.body.scrollTop > 800 || document.documentElement.scrollTop > 800) {
    backtotop.style.display = 'block'
  } else {
    backtotop.style.display = 'none'
  }
}

function scrollToTop() {
  var position =
    document.body.scrollTop || document.documentElement.scrollTop;
  if (position) {
    window.scrollBy(0, -Math.max(1, Math.floor(position / 10)));
    scrollAnimation = setTimeout("scrollToTop()", 5);
  } else clearTimeout(scrollAnimation);
}