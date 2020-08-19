$(".owl-works").owlCarousel({
    items: 3,
    loop: true,
    margin: 10,
    nav: true,
    autoplay: true,
    autoplayTimeout: 1500,
    autoplayHoverPause: true,
    responsiveClass: true,
    lazyLoad: true,
    responsive: {
        0: {
            items: 1, dots: false
            
        }, 600: {
            items: 3
            
        },
    },
    navText: ["<i class='fa fa-chevron-left'></i>", "<i class='fa fa-chevron-right'></i>"]
})

$("#owl-person").owlCarousel({
    loop: true,
    nav: false,
    autoplay: true,
    autoplayTimeout: 800,
    autoplayHoverPause: true,
    responsiveClass: true,
    lazyLoad: true,
    responsive: {
        0: {
            items: 1, dots: false, nav: true
        }, 600: {
            items: 4
        },
    },
    navText: ["<i class='fa fa-chevron-left'></i>", "<i class='fa fa-chevron-right'></i>"]
})



