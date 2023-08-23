async function makeAjaxRequest(url, method, data, successCallback, errorCallback) {
    $.ajax({
        url: url,
        method: method,
        data: data,
        contentType: 'application/json',
        success: function (response) {
            if (successCallback && typeof successCallback === 'function') {
                successCallback(response);
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            if (errorCallback && typeof errorCallback === 'function') {
                errorCallback(textStatus);
            }
        }
    });
}

async function makeAjaxRequest(url) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            url: url,
            method: "GET",
            contentType: 'application/json',
            success: function (response) {
                resolve(response);
            },
            error: function (xhr, textStatus, errorThrown) {
                reject(null);
            }
        });
    });
}

function getNoMovieResultHtml() {
    return ` <div class="text" id="no_sessions" style="display: block; padding: 30px 5px;">
		        <p>Sorry, we couldn't find any movies matching your criteria. Please refine your search or check back later for updates.</p>
	         </div>`;    
}