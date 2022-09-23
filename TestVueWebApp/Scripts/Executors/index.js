import Vue from 'vue';
import ExecutorCreateComponent from './ExecutorCreate.vue';
import ExecutorDeleteComponent from './ExecutorDelete.vue';
import ExecutorIndexComponent from './ExecutorIndex.vue';
import ExecutorEditComponent from './ExecutorEdit.vue';
import ExecutorDetailsComponent from './ExecutorDetails.vue';

new Vue({
    el: "#app",
    components: {
        ExecutorCreateComponent,
        ExecutorDeleteComponent,
        ExecutorIndexComponent,
        ExecutorEditComponent,
        ExecutorDetailsComponent
    }
})