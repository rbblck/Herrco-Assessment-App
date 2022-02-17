function calcSpeed(speed) {

    // Time = Distance/Speed
    var spanSelector = document.getElementById("news_markquee_cont");
    var spanLength = spanSelector.offsetWidth;
    var timeTaken = (spanLength / speed);

    spanSelector.style.animationDuration = timeTaken + "s";

}

function getNewsFlashTitles() {

    var funcCallStr = '/get_flash_news_titles';

    fetch(funcCallStr)
        .then(function (response) {
            return response.json();
        }).then(function (text) {

            var newsFlashArray = JSON.parse(text);

            var newsFlashMarHtml = "";

            if (newsFlashArray == "") {

                document.getElementById("breaking_news_cont").style.display = "none";

            } else {

                document.getElementById("breaking_news_cont").style.display = "block";

                for (var i = 0; i < newsFlashArray.length; i++) {

                    // var linkIcon = "<img style=\"margin-bottom: 5px;\" style=\"width: 35px; height: 35px;\" src=\"front_end/static/img/icons/link_icon.png\"/>"

                    var linkSrc = "/view_news_article?news_db_id=" + newsFlashArray[i][2];

                    newsFlashMarHtml += '<a style="color: black;" href="' + linkSrc + '">';
                    newsFlashMarHtml += '<span class="dot"></span>';
                    newsFlashMarHtml += newsFlashArray[i][0];
                    newsFlashMarHtml += " - Read More...";
                    // newsFlashMarHtml += linkIcon;
                    newsFlashMarHtml += '</a>';

                }

                document.getElementById("news_markquee_cont").innerHTML = newsFlashMarHtml;

                let constSpeed = 30
                calcSpeed(constSpeed)

            }

        });

}

getNewsFlashTitles();