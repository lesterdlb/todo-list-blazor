window.toggleTheme = isDark => {
	const body = document.body;
	if (isDark) {
		body.setAttribute('data-theme', 'dark');
		localStorage.setItem('theme', 'dark');
	} else {
		body.removeAttribute('data-theme');
		localStorage.setItem('theme', 'light');
	}
};

window.isDarkTheme = () => {
	const savedTheme = localStorage.getItem('theme');

	if (savedTheme === 'dark') {
		document.body.setAttribute('data-theme', 'dark');
		return true;
	} else {
		document.body.removeAttribute('data-theme');
		return false;
	}
};

window.Scroll = () => {
	document.documentElement.scrollTo({
		top: document.documentElement.scrollHeight,
		left: 0,
		behavior: 'smooth',
	});
};

document.addEventListener('DOMContentLoaded', () => {
	window.isDarkTheme();
});
