import Vue from 'vue';
import CreateComponent from './Create.vue';
import DeleteComponent from './Delete.vue';
import IndexComponent from './index.vue';
import EditComponent from './Edit.vue';
import DetailsComponent from './Details.vue';

new Vue({
    el: "#app",
    components: {
        CreateComponent,
        DeleteComponent,
        IndexComponent,
        EditComponent,
        DetailsComponent
    }
})