import Vue from 'vue';
import ReceptionCreateComponent from './ReceptionPointCreate.vue';
import ReceptionDeleteComponent from './ReceptionPointDelete.vue';
import ReceptionIndexComponent from './ReceptionPointIndex.vue';
import ReceptionEditComponent from './ReceptionPointEdit.vue';
import ReceptionDetailsComponent from './ReceptionPointDetails.vue';

new Vue({
    el: "#app",
    components: {
        ReceptionCreateComponent,
        ReceptionDeleteComponent,
        ReceptionIndexComponent,
        ReceptionEditComponent,
        ReceptionDetailsComponent
    }
})