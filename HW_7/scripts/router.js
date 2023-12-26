const pageRoutes = {
    "/": "/pages/main.html",
    "/blog": "/pages/blog.html",
    404: "/pages/404.html",
}

const handleLocation = async () => {
    const path = window.location.pathname;
    const route = pageRoutes[path] || pageRoutes[404];
    const html = await fetch(route).then((response) => response.text());
    document.querySelector("main").innerHTML = html;
};

const navigateTo = (e) => {
    e.preventDefault();
    window.history.pushState({}, "", e.target.href);
    handleLocation();
};

window.onpopstate = handleLocation;
window.navigateTo = navigateTo;
handleLocation();
