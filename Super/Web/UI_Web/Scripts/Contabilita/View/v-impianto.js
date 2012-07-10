//View
var View = function (spinner,  paginationDiv) {
    var self = this;

    this.Pagination = paginationDiv;

    this.Spin = function (waiting) {
        spinner.Spin(waiting);
    };
    this.StopSpin = function () {
        spinner.StopSpin();
    };

   

    //pagination
    this.Paginate = function (pageNum, pageSize, totalItems, action) {
        $(paginationDiv).paging(totalItems, {
            format: "- (qq.) < nnncnnn > (.pp)",
            perpage: pageSize,
            lapping: 0,
            page: pageNum,
            onSelect: function (page) {
                if (pageNum != page) {
                    action(page);
                }
            },
            onFormat: function (type) {

                switch (type) {
                    case 'left':
                        if (this.page > 5)
                            return '<em><a href="#' + this.value + '">' + this.value + '</a></em>';
                        return "";
                    case 'right':
                        if (this.page < (this.pages - 5))
                            return '<em><a href="#' + this.value + '">' + this.value + '</a></em>';
                        return "";
                    case 'block':

                        if (!this.active)
                            return '<span class="disabled"  title="Pagina ' + this.value + '">' + this.value + '</span>';
                        else if (this.value != this.page)
                            return '<em><a href="#' + this.value + '" title="Pagina ' + this.value + '">' + this.value + '</a></em>';
                        return '<span class="this-page">' + this.value + '</span>';

                    case 'next':

                        if (this.active)
                            return '<a href="#' + this.value + '" class="next">></a>';
                        return '<span class="disabled">></span>';

                    case 'prev':

                        if (this.active)
                            return '<a href="#' + this.value + '" class="prev"><</a>';
                        return '<span class="disabled"><</span>';

                    case 'first':

                        if (this.active)
                            return '<a href="#' + this.value + '" class="first">First</a>';
                        return '<span class="disabled">First</span>';

                    case 'last':

                        if (this.active)
                            return '<a href="#' + this.value + '" class="last">Last</a>';
                        return '<span class="disabled">Last</span>';

                    case "leap":
                        if (this.active && (this.page > 5) && (this.page < (this.pages - 5)))
                            return '<span class="break">...</span>';
                        return "";
                    case 'fill':
                        if (this.active)
                            return "Pages:&nbsp;";
                        return "";
                }
            }
        });
    }
}