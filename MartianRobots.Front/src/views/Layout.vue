<template>
    <v-container>
        <v-row>
            <v-col cols="12">
                <v-row >
                    <v-col cols="9" align="center">
                        <table v-if="$store.state.mars.x != -1 && $store.state.mars.y != -1" class="mt-5">
                            <tr v-for="r in $store.state.mars.y + 2">
                                <td align="center" v-for="c in $store.state.mars.x + 2">

                                    <span v-if="c == 1 && r != $store.state.mars.y + 2"> 
                                        {{$store.state.mars.y - (r - 1) }}
                                    </span>
                                    <span v-if="c != 1 && r == $store.state.mars.y + 2"> 
                                        {{c - 2}} 
                                    </span>

                                    <span v-if="c == $store.state.robot.x + 2 && 
                                            r == ($store.state.mars.y + 2) - ($store.state.robot.y + 1) && 
                                            ($store.state.robot.x != -1 && $store.state.robot.y != -1 && $store.state.robot.or != '') ">
                                        <v-icon>mdi-robot-outline</v-icon>
                                    </span>
                                    <span v-if="c == $store.state.robotOutput.x + 2 && 
                                            r == ($store.state.mars.y + 2) - ($store.state.robotOutput.y + 1) &&
                                            ($store.state.robotOutput.x != -1 && $store.state.robotOutput.y != -1 && $store.state.robotOutput.or != '') ">
                                        <v-icon color="green">mdi-robot-outline</v-icon>
                                    </span>
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
                                <v-btn color="success" @click="setMars" :disabled="mars_x == -1 || mars_y == -1">New Size</v-btn>
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
                            <v-btn class="mt-2" color="warning" @click="setRobot" :disabled="robot_x == -1 || robot_y == -1 || orientation == ''">Set Initial Position</v-btn>
                        </v-row>

                        <v-row justify="center" class="mt-5">
                            <h3>New Robot Position</h3>
                        </v-row>
                        <v-row class="mt-5">
                            <v-col cols="2" class="mt-5" align="">
                                <v-btn color="primary" @click="setLeft" :disabled="($store.state.robot.x == -1 || $store.state.robot.y == -1 || $store.state.robot.or == '')"><v-icon>mdi-chevron-left</v-icon></v-btn>
                            </v-col>
                            <v-col cols="2" class="mt-5" align="">
                                <v-btn color="primary" @click="setRight" :disabled="($store.state.robot.x == -1 || $store.state.robot.y == -1 || $store.state.robot.or == '')"><v-icon>mdi-chevron-right</v-icon></v-btn>
                            </v-col>
                            <v-col cols="3" class="mt-5" align="">
                                <v-btn color="primary" @click="setForward" :disabled="($store.state.robot.x == -1 || $store.state.robot.y == -1 || $store.state.robot.or == '')">Forward</v-btn>
                            </v-col>
                            <v-col cols="4" class="mt-5 offset" align="right">
                                <v-btn color="success" @click="setMovements" :disabled="($store.state.robot.x == -1 || $store.state.robot.y == -1 || $store.state.robot.or == '' || movements == '')">Enter</v-btn>
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
                            <v-col cols="6" class="mt-5" align="center">
                                <h3>Output</h3>
                            </v-col>
                            <v-col cols="6" class="mt-5" align="center">
                                <h3>Information</h3>
                            </v-col>
                        </v-row>
                        <v-row class="mt-5">
                            <v-col cols="6" align="center">
                                <v-textarea
                                outlined
                                label="Output"
                                rows="8"
                                v-model="$store.state.output"
                                readonly
                                ></v-textarea>
                            </v-col>
                            <v-col cols="6" align="center">
                                <v-text-field
                                    label="Robots Succeeded"
                                    v-model="$store.state.information.robotsSucceeded"
                                    outlined
                                    dense
                                    readonly
                                ></v-text-field>
                                <v-text-field
                                    label="Robots Lost"
                                    v-model="$store.state.information.robotsLost"
                                    outlined
                                    dense
                                    readonly
                                ></v-text-field>
                                <v-text-field
                                    label="Surface Unexplored"
                                    v-model="$store.state.information.surfaceUnexplored"
                                    outlined
                                    dense
                                    readonly
                                ></v-text-field>                                                                
                                <v-text-field
                                    label="Surface Explored"
                                    v-model="$store.state.information.surfaceExplored"
                                    outlined
                                    dense
                                    readonly
                                ></v-text-field>
                            </v-col>                                                        
                        </v-row>

                    </v-col>
                </v-row>            
            </v-col>
        </v-row>
    </v-container>
</template>

<script>
export default {
    name : "Layout",
    data (){
        return {
            mars_x : -1,
            mars_y : -1,
            robot_x : -1,
            robot_y : -1,
            orientations : ['N', 'E', 'S', 'W'],
            orientation : '',
            movements : '',
        }
    },
    methods : {
        async setMars() {
            let mars = {
                x : this.mars_x,
                y : this.mars_y
            }

            this.robot_x = -1
            this.robot_y = -1
            this.orientation = ''
            await this.$store.dispatch('deleteRobots')
            await this.$store.dispatch('deleteInformation')
            await this.$store.dispatch('deleteVisited')
            
            this.setRobot()
            await this.$store.dispatch('setMars', mars)

            await this.$store.dispatch('addInformation')
        },
        async setRobot() {
            let robot = {   
                x : this.robot_x,
                y : this.robot_y,
                or : this.orientation
            }
            this.$store.commit('setRobot', robot)
            this.$store.commit('setRobotOutput', {})

        },

        async setMovements() {
            await this.$store.dispatch('sendRobot')
            await this.$store.dispatch('getInformation')
            let robot = {
                x : -1,
                y : -1,
                or : '',
                movements : ''
            }
            this.movements = ''
            this.$store.commit('setRobot', robot)            
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
    computed : {
        updateMovements() {
            this.$store.commit('setMovements', this.movements)
            return this.movements
        }
    }
}
</script>

<style>
tr:last-child > td {
  border-right-style : hidden;
  border-bottom-style : hidden;
  border-left-style : hidden
}
td:nth-child(1) {  
  border-top-style : hidden;
  border-bottom-style : hidden;
  border-left-style : hidden
}
table {
    table-layout : fixed;
}
td {
  height : 1.4vw;
  width : 1.4vw;
}
table, th, td {
  border :  0.1px solid black;
  border-collapse : collapse;
}
button {
    margin : 5%;
}
</style>