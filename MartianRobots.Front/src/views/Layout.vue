<template>
    <v-container>
        <v-row>
            <v-col cols="12">
                <v-row >
                    <v-col cols="9" align="center">
                        <table class="mt-5">
                            <tr v-for="r in $store.state.mars.x">
                                <td v-for="c in $store.state.mars.y">
                                </td>
                            </tr>
                        </table>
                    </v-col>
                    <v-col cols="3" align="center">
                        <v-row justify="center" class="mt-5">
                            <h3>New Mars Size</h3>
                        </v-row>
                        <v-row class="mt-2">
                            <v-col>
                                <v-text-field
                                v-model.number="mars_x"
                                label="X"
                                type="number"
                                min="0"
                                max="50"
                                />
                            </v-col>
                            <v-col>
                                <v-text-field
                                v-model.number="mars_y"
                                label="Y"
                                type="number"
                                min="0"
                                max="50"
                                />
                            </v-col>
                            <v-col>
                                <v-btn color="success" @click="setMars">New Size</v-btn>
                            </v-col>
                        </v-row>
                        <v-row justify="center" class="mt-5">
                            <h3>Robot Initial Position</h3>
                        </v-row>
                        <v-row class="mt-2">
                            <v-col>
                                <v-text-field
                                v-model.number="robot_x"
                                type="number"
                                label="X"
                                min="0"
                                max="50"
                                />
                            </v-col>
                            <v-col>
                                <v-text-field
                                v-model.number="robot_y"
                                type="number"
                                label="Y"
                                min="0"
                                max="50"
                                />
                            </v-col>
                            <v-col>
                                <v-select
                                    :items="orientations"
                                    v-model="orientation"
                                    label="Orientation"
                                ></v-select>                                
                            </v-col>                            
                        </v-row>
                        <v-row justify="center" class="mt-2">
                            <v-btn class="mt-2" color="warning" @click="setRight">Set Initial Position</v-btn>
                        </v-row>

                        <v-row justify="center" class="mt-5">
                            <h3>New Robot Position</h3>
                        </v-row>
                        <v-row class="mt-5">
                            <v-col cols="2" class="mt-5" align="">
                                <v-btn color="primary" @click="setLeft"><v-icon>mdi-chevron-left</v-icon></v-btn>
                            </v-col>
                            <v-col cols="2" class="mt-5" align="">
                                <v-btn color="primary" @click="setRight"><v-icon>mdi-chevron-right</v-icon></v-btn>
                            </v-col>
                            <v-col cols="3" class="mt-5" align="">
                                <v-btn color="primary" @click="setForward">Forward</v-btn>
                            </v-col>
                            <v-col cols="4" class="mt-5 offset" align="right">
                                <v-btn color="success" @click="setMovements">Enter</v-btn>
                            </v-col>                            
                        </v-row>
                        <v-row class="mt-5">
                            <v-text-field
                            label="Movements"
                            v-model="updateMovements"
                            outlined
                            readonly
                            ></v-text-field>    
                        </v-row>

                        <v-row justify="center" class="mt-5">
                            <h3>Output</h3>
                        </v-row>
                        <v-row class="mt-5">
                            <v-textarea
                            outlined
                            label="Output"
                            rows="10"
                            v-model="output"
                            readonly
                            ></v-textarea>                            
                        </v-row>

                    </v-col>
                </v-row>            
            </v-col>
        </v-row>
    </v-container>
</template>

<script>
export default {
    name: "Layout",
    data (){
        return {
            mars_x: 0,
            mars_y: 0,
            robot_x: 0,
            robot_y: 0,
            orientations: ['N', 'E', 'S', 'W'],
            orientation: '',
            movements: '',
            output: ''

        }
    },
    methods: {
        setMars() {
            let mars = {
                x: this.mars_x,
                y: this.mars_y
            }
            this.$store.dispatch('setMars', mars)
        },
        setRobot() {
            let robot = {
                x: this.robot_x,
                y: this.robot_y,
                or: this.orientation
            }
            this.$store.commit('setRobot', robot)
        },

        setMovements() {
            this.$store.dispatch('sendRobot')            
        },

        setLeft() {
            this.movements = this.movements.concat('L')
        },
        setRight() {
            this.movements = this.movements.concat('R')
        },
        setForward() {
            this.movements = this.movements.concat('F')
        },
    },
    computed: {
        updateMovements() {
            this.$store.commit('setMovements', this.movements)
            return this.movements
        }
    }
}
</script>

<style>

table {
    table-layout: fixed;
}
td {
  height: 1.4vw;
  width: 1.4vw;
}
table, th, td {
  border:  0.1px solid black;
  border-collapse: collapse;
}
button {
    margin: 5%;
}
</style>