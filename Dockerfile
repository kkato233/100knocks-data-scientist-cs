FROM jupyter/base-notebook:ubuntu-22.04

# Install .NET CLI dependencies

ARG NB_USER=jovyan
ARG NB_UID=1000
ENV USER ${NB_USER}
ENV NB_UID ${NB_UID}
ENV HOME /home/${NB_USER}

WORKDIR ${HOME}

USER root
RUN apt-get update
RUN wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb
RUN rm packages-microsoft-prod.deb
RUN rm /etc/apt/sources.list.d/microsoft-prod.list
RUN apt update
RUN apt install -y dotnet-sdk-6.0


# dotnet sdk-6.0
#latest stable from nuget.org
RUN dotnet tool install --global Microsoft.dotnet-interactive --version 1.0.355307

# dotnet sdk-7.0
# RUN dotnet tool install -g Microsoft.dotnet-interactive --version 1.0.420501

ENV PATH="${PATH}:${HOME}/.dotnet/tools"
RUN dotnet interactive jupyter install

# Enable telemetry once we install jupyter for the image
ENV DOTNET_INTERACTIVE_CLI_TELEMETRY_OPTOUT=false

#Install nteract 
RUN pip install nteract_on_jupyter

RUN rm /tmp/* -R

# Copy notebooks

COPY ./work/ ${HOME}/notebooks/

RUN chown -R ${NB_UID} ${HOME}
USER ${USER}

# Set root to notebooks
WORKDIR ${HOME}
