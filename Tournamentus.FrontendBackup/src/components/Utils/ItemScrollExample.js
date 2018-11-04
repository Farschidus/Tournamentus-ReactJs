// https://stackoverflow.com/questions/27887911/handling-react-animation-with-horizontal-scrolling

var cellTemplate = '<cell data-col="DATACOL"><innercell><article></article></innercell></cell>';
var innerTemplate = '<article class="new"><innerarticle><h1>TITLE</h1><button>Alpha</button><button>Beta</button><button>Gamma</button></innerarticle></article>';
var numCells = 2;
var animating = 0;

$('body').on('click', 'article button', function(event){
    if (!animating) {
        var currentCell = parseInt($(this).parent().parent().parent().parent().attr('data-col'));
        var title = $(this).text();
        if (currentCell == numCells) {
            addCell(title);
        } else if (currentCell == numCells - 1) {
            changeArticle(title,numCells);
        } else {
            removeExtraCells(title,currentCell);
        }
    }
});

function removeExtraCells(title,currentCell) {
    var tempCurrentCell = currentCell;
    changeArticle(title,tempCurrentCell+1);
    while (tempCurrentCell < numCells) {
        tempCurrentCell++;
        deleteArticle(title,tempCurrentCell+1);
    }
    numCells = currentCell+1;
}

function addCell(title){
    numCells++
    var html = cellTemplate.replace('DATACOL',numCells);
    $('section').append(html);
    changeArticle(title,numCells);
}

function changeArticle(title,changingCol) {
    var cell = $('cell[data-col="'+changingCol+'"] innercell');
    var html = innerTemplate.replace('TITLE', title).replace('DATACOL', numCells - 1);
    cell.prepend(html);
    triggerAnimation(cell);
}

function deleteArticle(title,changingCol) {
    var cell = $('cell[data-col="'+changingCol+'"] innercell');
    var html = '<article></article>';
    cell.prepend(html).addClass('deleting');
    triggerAnimation(cell);
}

function triggerAnimation(cell) {
    cell.addClass('animating');
    window.setTimeout(function(event){
        cell.css('bottom','-100%');
        animating = 1;
    },50);
}

$('body').on('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend', 'innercell', function(event){
    if ( $(this).hasClass('deleting') ) {
        $(this).parent().remove();
    } else {
        $(this).children('article:last-child').remove();
        $(this).children('article.new').removeClass('new');
        $(this).removeClass('animating');
        $(this).css('bottom','0');
    }
    animating = 0;
});

/* other */
* {
    box-sizing: border-box;
}

section {
    display: flex;
    flex-flow:row;
    overflow-x: scroll;
    overflow-y: hidden;
    position: fixed;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background: #ddd;
}

cell {
    flex: none;
    -webkit-flex: none;
    display:block;
    height:100%;
    float:left;
    position:relative;
    width:166px;
}
innercell {
    display:block;
    height:200%;
    width:100%;
    position:absolute;
    left:0;
    bottom:0;
}
.animating {
    transition: bottom 1s ease-out;
}
article {
    display:block;
    padding:8px;
    height:50%;
    position:absolute;
    left:0;
    bottom:0;
}
article.new {
    bottom:auto;
    top:0;
}
innerarticle {
    display:block;
    padding: 10px 31px;
    background: #fff;
    overflow: auto;
    box-shadow: 2px 1px 4px rgba(0, 0, 0, 0.2);
    border-radius: 3px;
    height:100%;
}

innerarticle button {
    padding: 5px;
    margin: 5px 0px;
    width: 100%;
}