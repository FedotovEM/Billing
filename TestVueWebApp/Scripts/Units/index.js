import Vue from 'vue';
import UnitCreateComponent from './UnitCreate.vue';
import UnitDeleteComponent from './UnitDelete.vue';
import UnitIndexComponent from './UnitIndex.vue';
import UnitEditComponent from './UnitEdit.vue';
import UnitDetailsComponent from './UnitDetails.vue';

new Vue({
    el: "#app",
    components: {
        UnitCreateComponent,
        UnitDeleteComponent,
        UnitIndexComponent,
        UnitEditComponent,
        UnitDetailsComponent
    }
})