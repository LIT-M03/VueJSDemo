new Vue({
    el: '#appdiv',
    data: {
        people: [],
        person: {},
        editMode: false,
        sortLastNameAsc: true
    },
    ready: function () {
        this.getPeople();
    },
    methods: {
        getPeople: function () {
            var self = this;
            $.getJSON('/home/getpeople', function (p) {
                self.people = p;
            });
        },
        addPerson: function () {
            this.editMode = false;
            $(".modal").modal();
        },
        saveAdd: function () {
            var self = this;
            $.post("/home/addperson", this.person, function (person) {
                self.people.push(person);
                self.person = {};
                $(".modal").modal('hide');
            });
        },
        deletePerson: function (p) {
            var self = this;
            $.post('/home/delete', { id: p.Id }, function () {
                self.getPeople();
            });
        },
        editPerson: function (p) {
            this.editMode = true;
            this.person = p;
            $(".modal").modal();
        },
        saveEdit: function () {
            $.post('/home/update', this.person, function () {
                $(".modal").modal('hide');
            });
        },
        sortPeople: function() {
            this.sortLastNameAsc = !this.sortLastNameAsc;
            var self = this;
            this.people.sort(function (a, b) {
                if (self.sortLastNameAsc) {
                    var temp = a;
                    a = b;
                    b = temp;
                }

                return a.LastName > b.LastName ? 1 : -1;
            });
        }
    }
});