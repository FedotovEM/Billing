import Vue from 'vue';
import DisrepairCreateComponent from './DisrepairCreate.vue';
import DisrepairDeleteComponent from './DisrepairDelete.vue';
import DisrepairIndexComponent from './DisrepairIndex.vue';
import DisrepairEditComponent from './DisrepairEdit.vue';
import DisrepairDetailsComponent from './DisrepairDetails.vue';

new Vue({
    el: "#app",
    components: {
        DisrepairCreateComponent,
        DisrepairDeleteComponent,
        DisrepairIndexComponent,
        DisrepairEditComponent,
        DisrepairDetailsComponent
    }
})