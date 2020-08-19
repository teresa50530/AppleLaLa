//let ml4 = {};
//ml4.opacityIn = [0, 1];
//ml4.scaleIn = [0.2, 1];
//ml4.scaleOut = 3;
//ml4.durationIn = 800;
//ml4.durationOut = 600;
//ml4.delay = 500;

//anime.timeline({ loop: true })
//    .add({
//        targets: '.ml4 .letters-1',
//        opacity: ml4.opacityIn,
//        scale: ml4.scaleIn,
//        duration: ml4.durationIn
//    }).add({
//        targets: '.ml4 .letters-1',
//        opacity: 0,
//        scale: ml4.scaleOut,
//        duration: ml4.durationOut,
//        easing: "easeInExpo",
//        delay: ml4.delay
//    }).add({
//        targets: '.ml4 .letters-2',
//        opacity: ml4.opacityIn,
//        scale: ml4.scaleIn,
//        duration: ml4.durationIn
//    }).add({
//        targets: '.ml4 .letters-2',
//        opacity: 0,
//        scale: ml4.scaleOut,
//        duration: ml4.durationOut,
//        easing: "easeInExpo",
//        delay: ml4.delay
//    }).add({
//        targets: '.ml4 .letters-3',
//        opacity: ml4.opacityIn,
//        scale: ml4.scaleIn,
//        duration: ml4.durationIn
//    }).add({
//        targets: '.ml4 .letters-3',
//        opacity: 0,
//        scale: ml4.scaleOut,
//        duration: ml4.durationOut,
//        easing: "easeInExpo",
//        delay: ml4.delay
//    }).add({
//        targets: '.ml4',
//        opacity: 0,
//        duration: 500,
//        delay: 500
//    });
$('.owl-prev').css('padding-top', '0')
$('.owl-prev').css('border', 'none')
$('.owl-next').css('padding-top', '0')
$('.owl-next').css('border', 'none')

//animate css refactored
var ml4 = { opacityIn: [0, 1], scaleIn: [0.2, 1], scaleOut: 3, durationIn: 800, durationOut: 600, delay: 500 };
anime.timeline({ loop: !0 }).add({ targets: ".ml4 .letters-1", opacity: ml4.opacityIn, scale: ml4.scaleIn, duration: ml4.durationIn }).add({ targets: ".ml4 .letters-1", opacity: 0, scale: ml4.scaleOut, duration: ml4.durationOut, easing: "easeInExpo", delay: ml4.delay }).add({ targets: ".ml4 .letters-2", opacity: ml4.opacityIn, scale: ml4.scaleIn, duration: ml4.durationIn }).add({ targets: ".ml4 .letters-2", opacity: 0, scale: ml4.scaleOut, duration: ml4.durationOut, easing: "easeInExpo", delay: ml4.delay }).add({
    targets: ".ml4 .letters-3",
    opacity: ml4.opacityIn, scale: ml4.scaleIn, duration: ml4.durationIn
}).add({ targets: ".ml4 .letters-3", opacity: 0, scale: ml4.scaleOut, duration: ml4.durationOut, easing: "easeInExpo", delay: ml4.delay }).add({ targets: ".ml4", opacity: 0, duration: 500, delay: 500 });


